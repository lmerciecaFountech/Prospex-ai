using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Extensions;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.GraphDB.Strategies;
using Lomi.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public class AttributeRepository : RepositoryBase, IAttributeRepository
    {
        private static readonly double OnboardingGravity = 0.007;
        private static readonly double NormalGravity = 0.01;
        private static readonly double K1 = 1;
        private static readonly double K2 = 2;

        public async Task<double> GetGlobalAttributeAverageAsync(string id)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Attribute)
                    .Has(nameof(Vertex.Id).ToLower(), id)
                    .InE(EdgeLabel.Average)
                    .Values(nameof(AttributeEdge.Weight));
                //.Mean();

                //var result = await gremlin.ExecuteQueryFirstAsync<double>(query);
                //return result.HasValue ? result.Value : 0;

                var result = await gremlin.ExecuteQueryAsync<dynamic>(query);
                var resultStrings = result.OfType<string>().ToList();
                List<double> results = resultStrings.Select(x => double.Parse(x)).ToList();
                double average = results.Count > 0 ? results.Average() : 0.0;
                return average;
            }
        }

        public async Task<Maybe<Vertex>> GetAttributeByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return Maybe<Vertex>.None;

            using (var gremlin = GremlinEngine.GetInstance())
            {
                return await gremlin.GetVertexAsync(id);
            }
        }

        public async Task<Maybe<Vertex>> GetAttributeByValueAsync(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Maybe<Vertex>.None;

            return await GetAttributeByIdAsync(GuidHelper.Create(GuidHelper.DnsNamespace, value).ToString());
        }

        public async Task<List<BaseVertex>> GetAllAttributesAsync()
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery().V(VertexLabel.Attribute);
                var results = await gremlin.ExecuteQueryAsync<BaseVertex>(query);
                return results;
            }
        }

        public async Task<List<BaseEdge>> GetAllAttributesAsync(VertexId vertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .WithId(vertexId)
                    .OutE(EdgeLabel.Is, EdgeLabel.Mentions);

                var results = await gremlin.ExecuteQueryAsync<BaseEdge>(query);

                return results;
            }
        }

        public async Task<List<string>> GetAttributesIdAsync(string filteredUserId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                //var query = new GraphQuery()
                //    .V(VertexLabel.Person)
                //    .Has(nameof(Vertex.Id).ToLower(), filteredUserId)
                //    .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
                //    .InV(VertexLabel.Attribute)
                //    .As(nameof(Vertex.Id))
                //    .Select(nameof(Vertex.Id))
                //    .ByOrEmpty(nameof(Vertex.Id).ToLower());

                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), filteredUserId)
                    .OutE(EdgeLabel.Mentions)
                    .InV(VertexLabel.Attribute)
                    .As(nameof(Vertex.Id))
                    .Select(nameof(Vertex.Id))
                    .ByOrEmpty(nameof(Vertex.Id).ToLower());

                var results = await gremlin.ExecuteQueryAsync<string>(query);

                return results;
            }
        }

        public async Task SetAttributeAverageAsync(string id, double averageWeight)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Attribute)
                    .WithId(new VertexId(id))
                    .Property(nameof(AttributeEntity.Weight), averageWeight.ToString(CultureInfo.InvariantCulture));

                await gremlin.ExecuteQueryAsync(query);
            }
        }

        public async Task SetAttributeAverageAsync(AttributeEdgeDTO averageEdge)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .E()
                    .HasLabel(EdgeLabel.Average)
                    .Has(nameof(BaseEdge.Id).ToLower(), averageEdge.Id)
                    .OutV(VertexLabel.DNA)
                    .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
                    .Where(new Expression()
                        .InV(VertexLabel.Attribute)
                        .InE(EdgeLabel.Average)
                        .Has(nameof(BaseEdge.Id).ToLower(), averageEdge.Id))
                    .As(nameof(AttributeEdgeDTO.Id),
                        nameof(AttributeEdgeDTO.Weight),
                        nameof(AttributeEdgeDTO.Confidence),
                        nameof(AttributeEdgeDTO.Gravity),
                        nameof(AttributeEdgeDTO.Source))
                    .Select(nameof(AttributeEdgeDTO.Id),
                        nameof(AttributeEdgeDTO.Weight),
                        nameof(AttributeEdgeDTO.Confidence),
                        nameof(AttributeEdgeDTO.Gravity),
                        nameof(AttributeEdgeDTO.Source))
                    .By(nameof(BaseEdge.Id).ToLower())
                    .ByOrZero(nameof(AttributeEdge.Weight))
                    .ByOrZero(nameof(AttributeEdge.Confidence))
                    .By(nameof(AttributeEdge.UpdatedAt))
                    .By(nameof(AttributeEdge.Source));

                var result = await gremlin.ExecuteQueryAsync<AttributeEdgeDTO>(query);

                if (!averageEdge.Reinforcement.HasValue || averageEdge.Reinforcement == 0)
                {
                    foreach (var attributeEdge in result)
                    {
                        attributeEdge.Weight = attributeEdge.Weight - (Source.From(attributeEdge.Source) == Source.Onboarding ? OnboardingGravity : NormalGravity);
                        await gremlin.UpdateEdgeValueAsync(attributeEdge.Id, nameof(AttributeEdge.Weight), attributeEdge.Weight.ToString());
                    }
                }
                else
                {
                    averageEdge.Multiplier = averageEdge.Multiplier *
                        (1 + ((averageEdge.Reinforcement ?? 0) / (100 * K1))) *
                        (1 + ((DateTime.UtcNow - averageEdge.CreatedAt.ToDateTime()).TotalDays / (1000 * K2)));

                    await gremlin.UpdateEdgeValueAsync(averageEdge.Id, nameof(AttributeEdge.Reinforcement), 0.ToString());
                    await gremlin.UpdateEdgeValueAsync(averageEdge.Id, nameof(AttributeEdge.LastRefreshedAt), DateTime.UtcNow.Ticks.ToString());
                    await gremlin.UpdateEdgeValueAsync(averageEdge.Id, nameof(AttributeEdge.Multiplier), averageEdge.Multiplier.ToString());
                }

                var averageWeight = result.Average(x => x.Weight) * averageEdge.Multiplier;
                var averageConfidence = result.Average(x => x.Confidence);

                await gremlin.UpdateEdgeValueAsync(averageEdge.Id, nameof(AttributeEdge.UpdatedAt), DateTime.UtcNow.Ticks.ToString());
                await gremlin.UpdateEdgeValueAsync(averageEdge.Id, nameof(AttributeEdge.Weight), averageWeight.ToString());
                await gremlin.UpdateEdgeValueAsync(averageEdge.Id, nameof(AttributeEdge.Confidence), averageConfidence.ToString());
            }
        }

        public async Task ConnectAttributeAsync(VertexId vertexId, VertexId attributeId, AttributeEdge edge)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                await gremlin.AddOrUpdateEdgeAsync(vertexId.ToString(), attributeId.ToString(), edge);
            }
        }

        public async Task RemoveAllInCatalogueFlagsAsync()
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Attribute)
                    .Properties(nameof(AttributeEntity.InCatalogue))
                    .Drop();

                await gremlin.ExecuteQueryAsync(query);
            }
        }

        public async Task SetInCatalogueFlagForTopAttributesAsync(int count)
        {
            await RemoveAllInCatalogueFlagsAsync();

            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery().V(VertexLabel.Attribute)
                    .OrderByDecr(nameof(AttributeEntity.Weight))
                    .Limit(count)
                    .Property(nameof(AttributeEntity.InCatalogue), true.ToString(), false);

                await gremlin.ExecuteQueryAsync(query);
            }
        }

        public async Task<List<PersonAttributeCatalogDTO>> GetCatalogueAttributesAsync(int count)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Attribute)
                    .Has(nameof(AttributeEntity.InCatalogue), true.ToString())
                    .OrderByDecr(nameof(AttributeEntity.Weight))
                    .Limit(count)
                    .As(nameof(PersonAttributeCatalogDTO.AttributeVertexId),
                        nameof(PersonAttributeCatalogDTO.AttributeAverageWeight),
                        nameof(PersonAttributeCatalogDTO.AttributeValue),
                        nameof(PersonAttributeCatalogDTO.AttributeInfoBoxJson),
                        nameof(PersonAttributeCatalogDTO.AttributeDescription),
                        nameof(PersonAttributeCatalogDTO.AttributeCreatedAt))
                   .Select(nameof(PersonAttributeCatalogDTO.AttributeVertexId),
                        nameof(PersonAttributeCatalogDTO.AttributeAverageWeight),
                        nameof(PersonAttributeCatalogDTO.AttributeValue),
                        nameof(PersonAttributeCatalogDTO.AttributeInfoBoxJson),
                        nameof(PersonAttributeCatalogDTO.AttributeDescription),
                        nameof(PersonAttributeCatalogDTO.AttributeCreatedAt))
                   .ByOrEmpty(nameof(Vertex.Id).ToLower())
                   .ByOrEmpty(nameof(AttributeEntity.Weight))
                   .ByOrEmpty(nameof(AttributeEntity.Value))
                   .ByOrEmpty(nameof(AttributeEntity.InfoBoxJson))
                   .ByOrEmpty(nameof(AttributeEntity.Description))
                   .ByOrEmpty(nameof(AttributeEntity.CreatedAt));

                var results = await gremlin.ExecuteQueryAsync<PersonAttributeCatalogDTO>(query);

                return results;
            }
        }

        public async Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesWithPersonAsync(int count)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Attribute)
                    .As(nameof(PersonAttributeUsageDTO.AttributeVertexId))
                    .As(nameof(PersonAttributeUsageDTO.AttributeCreatedAt))
                    .Has(nameof(AttributeEntity.InCatalogue), true.ToString())
                    .InE(EdgeLabel.Average)
                    .As(nameof(PersonAttributeUsageDTO.AttributeAverageWeight))
                    .OutV(VertexLabel.DNA)
                    .InE(EdgeLabel.Has)
                    .OutV(VertexLabel.Person)
                    .As(nameof(PersonAttributeUsageDTO.PersonVertexId))
                    .Select(nameof(PersonAttributeUsageDTO.AttributeVertexId),
                        nameof(PersonAttributeUsageDTO.AttributeCreatedAt),
                        nameof(PersonAttributeUsageDTO.AttributeAverageWeight),
                        nameof(PersonAttributeUsageDTO.PersonVertexId))
                    .By(new Expression().Values(nameof(Vertex.Id).ToLower()))
                    .By(new Expression().Values(nameof(AttributeEntity.CreatedAt)))
                    .By(new Expression().Values(nameof(AttributeEdge.Weight)))
                    .By(new Expression().Values(nameof(Vertex.Id).ToLower()));

                var results = await gremlin.ExecuteQueryAsync<PersonAttributeUsageDTO>(query);

                return results;
            }
        }

        public async Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesByPersonIdAsync(VertexId vertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person, vertexId)
                    .As(nameof(PersonAttributeUsageDTO.PersonVertexId))
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .OutE(EdgeLabel.Average)
                    .As(nameof(PersonAttributeUsageDTO.AttributeAverageWeight))
                    .InV(VertexLabel.Attribute)
                    .Has(nameof(AttributeEntity.InCatalogue), true)
                    .As(nameof(PersonAttributeUsageDTO.AttributeVertexId))
                    .As(nameof(PersonAttributeUsageDTO.AttributeCreatedAt))
                    .Select(nameof(PersonAttributeUsageDTO.PersonVertexId),
                        nameof(PersonAttributeUsageDTO.AttributeAverageWeight),
                        nameof(PersonAttributeUsageDTO.AttributeVertexId),
                        nameof(PersonAttributeUsageDTO.AttributeCreatedAt))
                    .By(new Expression().Values(nameof(Vertex.Id).ToLower()))
                    .By(new Expression().Values(nameof(AttributeEdge.Weight)))
                    .By(new Expression().Values(nameof(Vertex.Id).ToLower()))
                    .By(new Expression().Values(nameof(AttributeEntity.CreatedAt)));

                var results = await gremlin.ExecuteQueryAsync<PersonAttributeUsageDTO>(query);

                return results;
            }
        }

        public async Task<List<PersonAttributeUsageDTO>> GetRandomPersonAttributesAsync(int count)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Shuffle()
                    .Limit(count)
                    .As(nameof(PersonAttributeUsageDTO.PersonVertexId))
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .OutE(EdgeLabel.Average)
                    .As(nameof(PersonAttributeUsageDTO.AttributeAverageWeight))
                    .InV(VertexLabel.Attribute)
                    .As(nameof(PersonAttributeUsageDTO.AttributeVertexId))
                    .As(nameof(PersonAttributeUsageDTO.AttributeCreatedAt))
                    .Select(nameof(PersonAttributeUsageDTO.PersonVertexId),
                        nameof(PersonAttributeUsageDTO.AttributeAverageWeight),
                        nameof(PersonAttributeUsageDTO.AttributeVertexId),
                        nameof(PersonAttributeUsageDTO.AttributeCreatedAt));

                var results = await gremlin.ExecuteQueryAsync<PersonAttributeUsageDTO>(query);

                return results;
            }
        }

        public async Task<List<PersonAttributeUsageDTO>> GetPersonsTopAttributesAsync(double minWeight, int count)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery().V(VertexLabel.Attribute)
                    .As(nameof(PersonAttributeUsageDTO.AttributeVertexId))
                    .As(nameof(PersonAttributeUsageDTO.AttributeCreatedAt))
                    .Where(new Expression()
                        .Values(nameof(AttributeEntity.Weight))
                        .Is(new Expression().Gt(minWeight)))
                    .InE(EdgeLabel.Average)
                    .As(nameof(PersonAttributeUsageDTO.AttributeAverageWeight))
                    .OutV(VertexLabel.DNA)
                    .InE(EdgeLabel.Has)
                    .OutV(VertexLabel.Person)
                    .As(nameof(PersonAttributeUsageDTO.AttributeAverageWeight));

                var results = await gremlin.ExecuteQueryAsync<PersonAttributeUsageDTO>(query);

                return results;
            }
        }

        public async Task<List<BaseVertex>> GetAllAttributesEdgesAsync(string prospexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Person.SourceId), prospexId)
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .OutE(EdgeLabel.Is, EdgeLabel.Mentions);

                var results = await gremlin.ExecuteQueryAsync<BaseVertex>(query);

                return results;
            }
        }

        public async Task<List<AttributeEdgeDTO>> GetAllAverageAttributesEdgesAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .OutE(EdgeLabel.Average)
                    .As(nameof(AttributeEdgeDTO.Id),
                        //nameof(AttributeEdgeDTO.Reinforcement),
                        nameof(AttributeEdgeDTO.CreatedAt),
                        nameof(AttributeEdgeDTO.Multiplier))
                    .Select(nameof(AttributeEdgeDTO.Id),
                            //nameof(AttributeEdgeDTO.Reinforcement),
                            nameof(AttributeEdgeDTO.CreatedAt),
                            nameof(AttributeEdgeDTO.Multiplier))
                    .By(nameof(BaseEdge.Id).ToLower())
                    //.By(nameof(AttributeEdge.Reinforcement))
                    .By(nameof(AttributeEdge.CreatedAt))
                    .By(nameof(AttributeEdge.Multiplier));

                var results = await gremlin.ExecuteQueryAsync<AttributeEdgeDTO>(query);

                return results;
            }
        }

        public async Task<List<SixAttributeDTO>> GetSixAttributesAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .OutE(EdgeLabel.Average)
                    .As(nameof(SixAttributeDTO.Confidence),
                        nameof(SixAttributeDTO.LastRefreshedAt),
                        nameof(SixAttributeDTO.Weight))
                    .InV(VertexLabel.Attribute)
                    .As(nameof(SixAttributeDTO.AttributeVertexId))
                    .Select(nameof(SixAttributeDTO.AttributeVertexId),
                        nameof(SixAttributeDTO.Confidence),
                        nameof(SixAttributeDTO.LastRefreshedAt),
                        nameof(SixAttributeDTO.Weight))
                    .ByOrEmpty(nameof(Vertex.Id).ToLower())
                    .ByOrZero(nameof(SixAttributeDTO.Confidence))
                    .ByOrZero(nameof(SixAttributeDTO.LastRefreshedAt))
                    .ByOrZero(nameof(SixAttributeDTO.Weight));

                var results = await gremlin.ExecuteQueryAsync<SixAttributeDTO>(query);

                return results;
            }
        }

        public async Task AddAttributeIfNotExistsAsync(AttributeDTO attributeDTO)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var graphQuery = new Expression();

                await CreateAttributeAndGroup(attributeDTO, gremlin);

                await gremlin.ExecuteQueryAsync(graphQuery);
            }
        }

        public async Task AddAttributesIfNotExistsAsync(IEnumerable<AttributeDTO> attributeDTOs)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var attributeModels = attributeDTOs as AttributeDTO[] ?? attributeDTOs.ToArray();

                if (attributeModels.Any())
                {
                    foreach (var attributeModel in attributeModels)
                    {
                        await Task.Delay(200);

                        await CreateAttributeAndGroup(attributeModel, gremlin);
                    }
                }
            }
        }


        #region Private Methods

        private static async Task CreateAttributeAndGroup(AttributeDTO attributeDTO, GremlinEngine gremlin)
        {
            if (attributeDTO.Attribute == null)
                return;

            attributeDTO.Edge.SetId(attributeDTO.SourceVertexId, attributeDTO.Attribute?.Id);

            var attributeVertexResolution = AttributeVertexResolutionStrategy.ForId(attributeDTO.Attribute.Id);
            await attributeVertexResolution.AddOrUpdateAsync(attributeDTO.Attribute);

            await gremlin.AddOrUpdateEdgeAsync(attributeDTO.SourceVertexId,
                attributeDTO.Attribute.Id, attributeDTO.Edge);

            if (attributeDTO.Group != null)
            {
                var attributeGroupVertexResolution = AttributeGroupVertexResolutionStrategy.ForId(attributeDTO.Group.Id);
                await attributeGroupVertexResolution.AddOrUpdateAsync(attributeDTO.Group);

                var attributeGroupEdge = new AttributeGroupEdge();
                attributeGroupEdge.SetId(attributeDTO.Attribute?.Id, attributeDTO.Group?.Id);
                await gremlin.AddOrUpdateEdgeAsync(attributeDTO.Attribute.Id,
                    attributeDTO.Group.Id, attributeGroupEdge);
            }
        }

        private static double GetAttributeConfidence(EdgeLabel edgeLabel, Source source, bool active = true, DateTime? lastUpdatedAt = null)
        {
            double confidence = 0;
            double gravityMultiplier = 0.01;
            int age = active ? 0 : 45;

            if (edgeLabel == EdgeLabel.Is)
            {
                confidence = 1;
            }
            else if (edgeLabel == EdgeLabel.Mentions)
            {
                confidence = 0.5;
            }

            // Onboarding data in A05 is twice as strong 
            confidence = source == Source.Onboarding ? confidence : confidence / 2;

            if (lastUpdatedAt.HasValue)
            {
                return confidence - (DateTime.UtcNow.Subtract(lastUpdatedAt.Value).TotalDays + age) * gravityMultiplier;
            }
            else
            {
                return confidence - age * gravityMultiplier;
            }
        }

        private static double GetAttributeWeight(Source source, double? weight = null, DateTime? lastUpdatedAt = null)
        {
            double value = 0;

            if (weight.HasValue)
            {
                value = weight.Value;
                var gravityMultiplier = source == Source.Onboarding ? 0.007 : 0.01;

                if (lastUpdatedAt.HasValue)
                {
                    return value - DateTime.UtcNow.Subtract(lastUpdatedAt.Value).TotalDays * gravityMultiplier;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                if (source == Source.RecommendationEngine)
                {
                    value = 0.5;
                }
                else
                {
                    value = 0.7;
                }

                return value;
            }
        }

        #endregion


        //public async Task<Vertex> AddAttributeAsync(AttributeEntity attributeEntity)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        return await gremlin.GetOrAddVertexAsync(VertexLabel.Attribute, attributeEntity, attributeEntity.Value);
        //    }
        //}

        //public async Task AddAttributeToAsync(Vertex dnaVertex, IEnumerable<string> keywords, EdgeLabel edgeLabel, Source source)
        //{
        //    foreach (var keyword in keywords)
        //    {
        //        var attributeVertex = await AddAttributeAsync(new AttributeEntity(keyword));

        //        //TODO

        //        //await AttributesDao.ConnectAttribute(dnaVertex.GetId(), attributeVertex.GetId(), new AttributeEdge(edgeLabel, source,
        //        //                LomiFunctions.GetAttributeConfidence(edgeLabel, Source.Onboarding, true),
        //        //                LomiFunctions.GetAttributeWeight(Source.Onboarding), true));
        //    }
        //}

        //public async Task<Vertex> AddAttributeGroupAsync(Vertex attrVertex, AttributeGroup attributeGroup, Source source)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var attrGroupVertex = await gremlin.GetOrAddVertexAsync(VertexLabel.AttributeGroup, new AttributeGroupEntity(attributeGroup), attributeGroup.Value, source);
        //        await ConnectAttributeAsync(attrVertex.GetId(), attrGroupVertex.GetId(), new StandardEdge(EdgeLabel.Belongs));

        //        return attrGroupVertex;
        //    }
        //}

        //    public async Task<Vertex> GetAttributeAsync(AttributeEntity attributeEntity)
        //    {
        //        using (var gremlin = GremlinEngine.GetInstance())
        //        {
        //            return await gremlin.GetVertexAsync(VertexLabel.Attribute, attributeEntity, attributeEntity.Value);
        //        }
        //    }

        //    public async Task<DnaAveragesDTO> GetDnaAverages(string prospexId)
        //    {
        //        using (var gremlin = GremlinEngine.GetInstance())
        //        {
        //            var query = new GraphQuery().V().HasLabel(VertexLabel.DNA)
        //                                            .Has(nameof(Person.ProspexId), prospexId)
        //                                            .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
        //                                            .GroupBy(new GremlinExpression("inV().hasLabel('Attribute').values('Value')"))
        //                                            .By(new GremlinExpression("valueMap('Weight', 'Confidence').fold()"));

        //            var result = await gremlin.ExecuteQueryAsync<Dictionary<string, List<ConfidenceWeightValueDTO>>>(query);

        //            var attributeAveragesList = new List<AttributeAverages>();
        //            foreach (var item in result)
        //            {
        //                foreach (var dictionary in item)
        //                {
        //                    string attributeValue = dictionary.Key;
        //                    double averageConfidence = dictionary.Value.Average(x => double.Parse(x.Confidence));
        //                    double averageWeight = dictionary.Value.Average(x => double.Parse(x.Weight));

        //                    attributeAveragesList.Add(new AttributeAverages(attributeValue, averageConfidence, averageWeight));
        //                }

        //            }

        //            return new DnaAveragesDTO(prospexId, attributeAveragesList);
        //        }
        //    }
        //}
    }
}