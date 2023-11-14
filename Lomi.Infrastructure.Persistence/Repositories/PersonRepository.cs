using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.GraphDB.Extensions;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.GraphDB.Strategies;
using Lomi.Infrastructure.Persistence.Interfaces;
using Lomi.Infrastructure.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : RepositoryBase, IPersonRepository
    {
        private static readonly List<Tuple<string, string>> _dictionary = new List<Tuple<string, string>>()
        {
            Tuple.Create("chief academic officer","CAO"),
            Tuple.Create("chief accounting officer","CAO"),
            Tuple.Create("chief administrative officer","CAO"),
            Tuple.Create("chief artificial intelligence officer","CAIO"),
            Tuple.Create("chief analytics officer","CAO"),
            Tuple.Create("chief architect","CA"),
            Tuple.Create("chief audit executive","CAE"),
            Tuple.Create("chief business officer","CBO"),
            Tuple.Create("chief business development officer","CBDO"),
            Tuple.Create("chief brand officer","CBO"),
            Tuple.Create("chief commercial officer","CCO"),
            Tuple.Create("chief communications officer","CCO"),
            Tuple.Create("chief compliance officer","CCO"),
            Tuple.Create("chief content officer","CCO"),
            Tuple.Create("chief creative officer","CCO"),
            Tuple.Create("chief customer officer","CCO"),
            Tuple.Create("chief development officer","CDO"),
            Tuple.Create("chief data officer","CDO"),
            Tuple.Create("chief design officer","CDO"),
            Tuple.Create("chief digital officer","CDO"),
            Tuple.Create("chief diversity officer","CDO"),
            Tuple.Create("chief engineering officer","CEngO"),
            Tuple.Create("chief executive officer","CEO"),
            Tuple.Create("chief experience officer","CXO"),
            Tuple.Create("chief financial officer","CFO"),
            Tuple.Create("chief gaming officer","CGO"),
            Tuple.Create("chief human resources officer","CHRO"),
            Tuple.Create("chief information officer","CIO"),
            Tuple.Create("chief information security officer","CISO"),
            Tuple.Create("chief innovation officer","CINO"),
            Tuple.Create("chief investment officer","CIO"),
            Tuple.Create("chief information technology officer","CITO"),
            Tuple.Create("chief knowledge officer","CKO"),
            Tuple.Create("chief legal officer","CLO"),
            Tuple.Create("chief learning officer","CLO"),
            Tuple.Create("chief marketing officer","CMO"),
            Tuple.Create("chief medical officer","CMO"),
            Tuple.Create("chief networking officer","CNO"),
            Tuple.Create("chief nursing officer","CNO"),
            Tuple.Create("chief operating officer","COO"),
            Tuple.Create("chief privacy officer","CPO"),
            Tuple.Create("chief process officer","CPO"),
            Tuple.Create("chief procurement officer","CPO"),
            Tuple.Create("chief product officer","CPO"),
            Tuple.Create("chief quality officer","CQO"),
            Tuple.Create("chief research and development officer","CRDO"),
            Tuple.Create("chief research officer","CRO"),
            Tuple.Create("chief revenue officer","CRO"),
            Tuple.Create("chief risk officer","CRO"),
            Tuple.Create("chief system engineer ","CSE "),
            Tuple.Create("chief security officer","CSO"),
            Tuple.Create("chief sales officer","CSO"),
            Tuple.Create("chief science officer","CSO"),
            Tuple.Create("chief strategy officer","CSO"),
            Tuple.Create("chief sustainability officer","CSO"),
            Tuple.Create("chief technology officer","CTO"),
            Tuple.Create("chief value officer","CVO"),
            Tuple.Create("chief visionary officer","CVO"),
            Tuple.Create("chief web officer","CWO"),
        };
        private readonly AttributeRepository _attributeRepository;
        private readonly LocationRepository _locationRepository;

        public PersonRepository()
        {
            _attributeRepository = new AttributeRepository();
            _locationRepository = new LocationRepository();
        }

        public async Task<Vertex> AddAsync(Person person, Source source)
        {
            var strategy = PersonVertexResolutionStrategy.For(person);
            var personVertex = await strategy.AddOrUpdateAsync(person);

            await AddEmploymentsAsync(person.EmploymentHistory, personVertex, source);

            await AddLocationsAsync(person.Location, personVertex, source);

            await AddOccupationsAsync(person.Occupations, personVertex, source);

            await AddSkillsAsync(person.Skills, personVertex, source);

            await AddEducationHistoryAsync(person.EducationList, personVertex, source);

            return personVertex;
        }

        public async Task ConnectToCompanyAsync(Vertex personVertex, Vertex companyVertex, EdgeLabel label, Source source)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                await gremlin.AddOrUpdateEdgeAsync(personVertex.Id, companyVertex.Id, new StandardEdge(label, source));
            }
        }

        public async Task AddLeadAsync(string personVertexId, string leadVertexId, double six, DateTime createdAt, DeliveryStatus deliveryStatus)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var leadEdge = new LeadEdge();
                leadEdge.Six = six;
                leadEdge.CreatedAt = createdAt.Ticks;
                leadEdge.DeliveryStatus = deliveryStatus;

                await gremlin.AddOrUpdateEdgeAsync(personVertexId, leadVertexId, leadEdge);
            }
        }

        /// <summary>
        /// Set the amount of required daily leads for each user.
        /// </summary>
        public async Task SetRDLAsync(string personVertexId, int rdl)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                //var query = new GraphQuery()
                //    .V(VertexLabel.Person)
                //    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                //    .Values(nameof(Person.ProfileCompletion));

                //var results = await gremlin.ExecuteQueryAsync<int>(query);

                //if (results.Any())
                //{
                //    var profileCompletion = results.FirstOrDefault();

                //    query = new GraphQuery()
                //    .V(VertexLabel.Person)
                //    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                //    .OutE(EdgeLabel.Has)
                //    .InV(VertexLabel.DNA)
                //    .Property(nameof(Dna.RDL), (profileCompletion / 10).ToString());

                //    await gremlin.ExecuteQueryAsync(query);
                //}

                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .Property(nameof(Dna.RDL), rdl.ToString());

                await gremlin.ExecuteQueryAsync(query);
            }
        }

        public async Task<int> GetRequiredDailyLeadsAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .Values(nameof(Dna.RDL));

                var result = await gremlin.ExecuteQueryFirstAsync<int>(query);

                return result.HasValue
                    ? result.Value
                    : 0;
            }
        }

        public async Task<int> GetUtcOffsetAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .ValuesOrZero(nameof(Person.UtcOffset));

                var possibleUtc = await gremlin.ExecuteQueryFirstAsync<int>(query);

                return possibleUtc.HasValue
                    ? possibleUtc.Value
                    : 0;
            }
        }

        public async Task<string> GetLomiIdAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .ValuesOrEmpty(nameof(Person.LomiId));

                var possibleLomiId = await gremlin.ExecuteQueryFirstAsync<string>(query);

                return possibleLomiId.HasValue
                    ? possibleLomiId.Value
                    : string.Empty;
            }
        }

        public async Task<Vertex> AddOrGetDnaAsync(Vertex personVertex)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var strategy = DnaVertexResolutionStrategy.ForPersonId(personVertex.Id);

                var possibleDnaVertex = await gremlin.AddOrUpdateVertexAsync(strategy, VertexLabel.DNA, new Dna(personVertex.Id));
                var dnaVertex = possibleDnaVertex.Value;

                if (dnaVertex != null)
                    await gremlin.AddOrUpdateEdgeAsync(personVertex.Id, dnaVertex.Id, new StandardEdge(EdgeLabel.Has));

                return dnaVertex;
            }
        }

        public async Task FlagDnaAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .Property(nameof(Dna.DCF), true.ToString());

                await gremlin.ExecuteQueryAsync(query);
            }
        }

        public async Task<List<PersonFlaggedDnaDTO>> GetFlaggedDnasAsync()
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.DNA)
                    .Where(new Expression().LessThan(nameof(Dna.LastRecommendationUpdateAt), DateTime.UtcNow.Date.Ticks))
                    .As(nameof(PersonFlaggedDnaDTO.DnaVertexId))
                    .As(nameof(PersonFlaggedDnaDTO.DnaRDL))
                    .As(nameof(PersonFlaggedDnaDTO.DnaReLastUpdatedAt))
                    .InE(EdgeLabel.Has)
                    .OutV(VertexLabel.Person)
                    .As(nameof(PersonFlaggedDnaDTO.PersonVertexId))
                    .As(nameof(PersonFlaggedDnaDTO.PersonUtcOffset))
                    .As(nameof(PersonFlaggedDnaDTO.NumberOfLeads))
                    .Select(nameof(PersonFlaggedDnaDTO.DnaVertexId),
                        nameof(PersonFlaggedDnaDTO.DnaRDL),
                        nameof(PersonFlaggedDnaDTO.DnaReLastUpdatedAt),
                        nameof(PersonFlaggedDnaDTO.PersonVertexId),
                        nameof(PersonFlaggedDnaDTO.PersonUtcOffset),
                        nameof(PersonFlaggedDnaDTO.NumberOfLeads))
                    .By(nameof(Vertex.Id).ToLower())
                    .By(nameof(Dna.RDL))
                    .By(nameof(Dna.LastRecommendationUpdateAt))
                    .By(nameof(Vertex.Id).ToLower())
                    .By(nameof(Person.UtcOffset))
                    .By(new Expression()
                        .OutE(EdgeLabel.Lead)
                        .Not(new Expression().Has(nameof(LeadEdge.DeliveryStatus), ((int)DeliveryStatus.Delivered).ToString()))
                        .Count());

                var result = await gremlin.ExecuteQueryAsync<PersonFlaggedDnaDTO>(query);

                return result;
            }
        }

        public async Task<bool> IsLockedAsync(string id)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var strategy = PersonVertexResolutionStrategy.ForId(id);
                var personVertex = await strategy.GetAsync();

                return personVertex.HasValue && personVertex.Value.GetProperty<bool>(nameof(Person.IsLocked));
            }
        }

        public async Task CopyAttributesFromPersonToDnaAsync(string personId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                //var personStrategy = PersonVertexResolutionStrategy.ForId(personId);
                //var maybePersonVertex = await personStrategy.GetAsync();

                //if (!maybePersonVertex.HasValue)
                //    return;

                var dnaStrategy = DnaVertexResolutionStrategy.ForPersonId(personId);
                var possibleDnaVertex = await dnaStrategy.GetAsync();
                //var possibleDnaVertex = await gremlin.AddOrUpdateVertexAsync(dnaStrategy, VertexLabel.DNA, new Dna(maybePersonVertex.Value.Id));
                var dnaVertex = possibleDnaVertex.Value;

                //if (dnaVertex == null)
                //    return;

                //await gremlin.AddOrUpdateEdgeAsync(maybePersonVertex.Value.Id, dnaVertex.Id, new StandardEdge(EdgeLabel.Has));

                //var dnaExpression = new Expression()
                //    .OutV(VertexLabel.DNA)
                //    .WithId(dnaVertex.GetId());

                //var query = new GraphQuery()
                //    .E()
                //    .HasLabel(EdgeLabel.Is, EdgeLabel.Mentions)
                //    .Where(dnaExpression);

                var query = new GraphQuery()
                    .V()
                    .HasId(personId)
                    .OutE(EdgeLabel.Is, EdgeLabel.Mentions);

                var attributes = await gremlin.ExecuteQueryAsync<BaseEdge>(query);

                foreach (var attributeViewModel in attributes)
                {
                    var edgeLabel = EdgeLabel.From(attributeViewModel.Label);
                    var source = Source.From(attributeViewModel.GetProperty<string>(nameof(AttributeEdge.Source)));

                    var attributeEdge = new AttributeEdge(edgeLabel, source, personId)
                    {
                        Origin = personId,
                        CreatedAt = attributeViewModel.GetProperty<long>(nameof(AttributeEdge.CreatedAt)),
                        IsActive = true,
                        Confidence = GetAttributeConfidence(edgeLabel, Source.Onboarding),
                        Weight = GetAttributeWeight(source)
                    };

                    await gremlin.AddOrUpdateEdgeAsync(dnaVertex.Id, attributeViewModel.InV, attributeEdge);

                    await Task.Delay(500);

                    var averageAttributeEdge = new AttributeEdge(EdgeLabel.Average, source, personId) { Weight = attributeEdge.Weight, Confidence = attributeEdge.Confidence };

                    await gremlin.AddOrUpdateEdgeAsync(dnaVertex.Id, attributeViewModel.InV, averageAttributeEdge);

                    await Task.Delay(500);
                }

            }
        }

        public async Task CopyAttributesFromReinforcementToDnaAsync(string prospexId, ReinforcementType reinforcementType, string originId, params EdgeLabel[] edgeLabels)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                //var personStrategy = PersonVertexResolutionStrategy.ForProspexId(prospexId);
                //var personStrategy = PersonVertexResolutionStrategy.ForId(prospexId);
                //var maybePersonVertex = await personStrategy.GetAsync();

                //if (!maybePersonVertex.HasValue)
                //    return;

                var dnaStrategy = DnaVertexResolutionStrategy.ForProspexId(prospexId);
                //var dnaStrategy = DnaVertexResolutionStrategy.ForPersonId(prospexId);
                var possibleDnaVertex = await dnaStrategy.GetAsync();
                var dnaVertex = possibleDnaVertex.Value;

                //var dnaVertex = await dnaStrategy.AddOrUpdateAsync(new Dna(maybePersonVertex.Value.Id));

                //await gremlin.AddOrUpdateEdgeAsync(maybePersonVertex.Value.Id, dnaVertex.Id, new StandardEdge(EdgeLabel.Has));

                //var query = new GraphQuery()
                //    .V()
                //    .HasLabel(VertexLabel.Person)
                //    .Has(nameof(Person.SourceId), prospexId)
                //    .OutE(EdgeLabel.Accepted)
                //    .InV(VertexLabel.Person)
                //    .Has(nameof(Vertex.Id).ToLower(), originId)
                //    .OutE(EdgeLabel.Is, EdgeLabel.Mentions);

                var query = new GraphQuery()
                    .V()
                    .HasLabel(VertexLabel.Person)
                    .Has(nameof(Person.ProspexId), prospexId)
                    .OutE(EdgeLabel.Accepted)
                    .InV(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), originId)
                    //.Has(nameof(Vertex.Id).ToLower(), originId)
                    //.OutE(EdgeLabel.Is, EdgeLabel.Mentions);
                    .OutE(EdgeLabel.Mentions);

                var attributes = await gremlin.ExecuteQueryAsync<BaseEdge>(query);

                foreach (var attributeViewModel in attributes)
                {
                    var edgeLabel = EdgeLabel.From(attributeViewModel.Label);
                    var source = Source.From(attributeViewModel.GetProperty<string>(nameof(AttributeEdge.Source)));

                    var attributeEdge = new AttributeEdge(edgeLabel, source, originId)
                    {
                        Confidence = GetAttributeConfidence(edgeLabel, Source.Onboarding),
                        Weight = GetAttributeWeight(source)
                    };

                    var attributeVertex = new Vertex { Id = attributeViewModel.InV, Label = attributeViewModel.InVLabel };

                    await gremlin.AddOrUpdateEdgeAsync(dnaVertex.Id, attributeVertex.Id, attributeEdge);

                    await CreateOrUpdateAverageReinforcementAsync(dnaVertex, attributeVertex, reinforcementType, originId, source, false);
                }
            }
        }

        public async Task UpdateAttributesFromReinforcementToDnaAsync(string prospexId, ReinforcementType reinforcementType, string originId = null, params EdgeLabel[] edgeLabels)
        {
            if (edgeLabels == null)
                return;

            using (var gremlin = GremlinEngine.GetInstance())
            {
                //var personStrategy = PersonVertexResolutionStrategy.ForProspexId(prospexId);
                //var personStrategy = PersonVertexResolutionStrategy.ForId(prospexId);
                //var maybePersonVertex = await personStrategy.GetAsync();

                //if (!maybePersonVertex.HasValue)
                //   return;

                //var dnaStrategy = DnaVertexResolutionStrategy.ForProspexId(prospexId);
                //var dnaStrategy = DnaVertexResolutionStrategy.ForPersonId(prospexId);
                //var possibleDnaVertex = await gremlin.AddOrUpdateVertexAsync(dnaStrategy, VertexLabel.DNA, new Dna(maybePersonVertex.Value.Id));
                //var dnaVertex = possibleDnaVertex.Value;

                var dnaStrategy = DnaVertexResolutionStrategy.ForProspexId(prospexId);
                var possibleDnaVertex = await dnaStrategy.GetAsync();
                var dnaVertex = possibleDnaVertex.Value;

                //if (dnaVertex == null)
                //    return;

                //await gremlin.AddOrUpdateEdgeAsync(maybePersonVertex.Value.Id, dnaVertex.Id, new StandardEdge(EdgeLabel.Has));

                //var query = new GraphQuery()
                //    .V(VertexLabel.Person)
                //    .Has(nameof(Person.SourceId), prospexId)
                //    .OutE(edgeLabels)
                //    .InV(VertexLabel.Person);

                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Person.ProspexId), prospexId)
                    .OutE(edgeLabels)
                    .InV(VertexLabel.Person);

                if (originId != null)
                {
                    query = query.Has(nameof(Vertex.Id).ToLower(), originId);
                }

                query = query.OutE(EdgeLabel.Is, EdgeLabel.Mentions);

                var attributes = await gremlin.ExecuteQueryAsync<BaseEdge>(query);

                foreach (var attributeViewModel in attributes)
                {
                    //var edgeLabel = EdgeLabel.From(attributeViewModel.Label);
                    var source = Source.From(attributeViewModel.GetProperty<string>(nameof(AttributeEdge.Source)));
                    //var attributeEdge = new AttributeEdge(edgeLabel, source, originId);

                    //attributeEdge.Origin = prospexId;
                    //attributeEdge.Confidence = LomiFunctions.GetAttributeConfidence(attributeEdge.Label, Source.Onboarding);
                    //attributeEdge.Weight = LomiFunctions.GetAttributeWeight(attributeEdge.Source);

                    var attributeVertex = new Vertex { Id = attributeViewModel.InV, Label = attributeViewModel.InVLabel };

                    //var succeeded = await gremlin.UpdateEdgeValuesAsync(
                    //    dnaVertex,
                    //    attributeVertex,
                    //    attributeEdge.Label,
                    //    new Dictionary<string, string>
                    //    {
                    //        { nameof(AttributeEdge.Confidence), attributeEdge.Confidence.ToString() },
                    //        { nameof(AttributeEdge.Weight), attributeEdge.Weight.ToString() }
                    //    });

                    await CreateOrUpdateAverageReinforcementAsync(dnaVertex, attributeVertex, reinforcementType, originId, source, true);
                }
            }
        }

        public async Task InteractAsync(string userId, string leadId, InteractionType interactionType, string referralId = null)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var userStrategy = PersonVertexResolutionStrategy.ForProspexId(userId);
                //var userStrategy = PersonVertexResolutionStrategy.ForId(userId);
                //var leadStrategy = PersonVertexResolutionStrategy.ForId(leadId);
                var leadStrategy = PersonVertexResolutionStrategy.ForLomiId(leadId);

                var userVertex = await userStrategy.GetAsync();
                var leadVertex = await leadStrategy.GetAsync();

                if (userVertex.HasValue && leadVertex.HasValue)
                {
                    if (interactionType == InteractionType.Referred)
                    {
                        var referralStrategy = PersonVertexResolutionStrategy.ForId(referralId);
                        var referralVertex = await referralStrategy.GetAsync();

                        if (referralVertex.HasValue)
                        {
                            await gremlin.AddOrUpdateEdgeAsync(userVertex.Value.Id, leadVertex.Value.Id, new ReinforcementEdge(EdgeLabel.Refer, Source.Onboarding, userVertex.Value.Id));
                            await gremlin.AddOrUpdateEdgeAsync(referralVertex.Value.Id, leadVertex.Value.Id, new ReinforcementEdge(EdgeLabel.Referred, Source.Onboarding, userVertex.Value.Id));

                            //var reinforcementType = interactionType.GetReinforcementType();
                            //if (reinforcementType.HasValue)
                            //{
                            //    await CopyAttributesFromReinforcementToDnaAsync(userId, reinforcementType.Value, userVertex.Value.Id, EdgeLabel.Referred);
                            //}
                        }
                    }
                    else
                    {
                        var edge = new StandardEdge(EdgeLabel.From(interactionType.ToString()), Source.Onboarding);
                        await gremlin.AddOrUpdateEdgeAsync(userVertex.Value.Id, leadVertex.Value.Id, edge);
                        var reinforcementType = interactionType.GetReinforcementType();
                        if (reinforcementType.HasValue)
                        {
                            if (interactionType == InteractionType.Accepted)
                            {
                                await CopyAttributesFromReinforcementToDnaAsync(userId, reinforcementType.Value, leadVertex.Value.Id, edge.Label);
                            }
                            else if(interactionType == InteractionType.Declined || interactionType == InteractionType.Skipped || interactionType == InteractionType.AutoDeclined)
                            {
                                await UpdateAttributesFromReinforcementToDnaAsync(userId, reinforcementType.Value, leadVertex.Value.Id, edge.Label);
                            }
                        }
                    }
                }
            }
        }

        public async Task AddIdealClientsAsync(List<Person> idealClients, Source source, Vertex dnaVertex, Vertex personVertex)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                if (idealClients == null)
                    return;

                foreach (var item in idealClients)
                {
                    var idealClientVertex = await AddAsync(item, source);
                    var attributes = await _attributeRepository.GetAllAttributesAsync(idealClientVertex.GetId());

                    foreach (var attribute in attributes)
                    {
                        var edgeLabel = EdgeLabel.From(attribute.Label);
                        var isValid = attribute.GetProperty<bool>(nameof(AttributeEdge.IsValid));

                        var attributeEdge = new AttributeEdge(edgeLabel, Source.Onboarding, idealClientVertex.Id)
                        {

                        };

                        await _attributeRepository.ConnectAttributeAsync(dnaVertex.GetId(), new VertexId(attribute.InV), attributeEdge);

                        if (personVertex != null)
                        {
                            await gremlin.AddOrUpdateEdgeAsync(personVertex.Id, idealClientVertex.Id, new StandardEdge(EdgeLabel.Ideal, source));
                        }
                    }
                }
            }
        }

        public async Task<List<string>> GetLeadsAsync(string personVertexId, List<LeadFilter> leadFilters, string locationId = null, string ignoreLocationId = null, int? limit = null)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var mainLocationQuery = locationId == null ? new Expression().V(VertexLabel.Person)
                    : new Expression().V(VertexLabel.Location).Has(nameof(Vertex.Id).ToLower(), locationId);

                var ignoreLocationQuery = ignoreLocationId == null ? null
                    : new Expression().Not(new Expression().Has(nameof(Vertex.Id).ToLower().ToString(), ignoreLocationId));

                var notInLocationQuery = ignoreLocationId == null ? null
                    : new Expression()
                        .OutE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)
                        .InV(VertexLabel.Location)
                        .Where(new Expression()
                        .Until(new Expression()
                            .Where(new Expression()
                                .Has(nameof(Vertex.Id).ToLower(), ignoreLocationId)))
                        .Repeat(new Expression()
                            .OutE(EdgeLabel.Belongs)
                            .InV(VertexLabel.Location)).Count().Is(new Expression().Eq(0)))
                        .Count().Is(new Expression().Lt(1));

                if (leadFilters.Contains(LeadFilter.Country) ||
                    leadFilters.Contains(LeadFilter.Country20) ||
                    leadFilters.Contains(LeadFilter.City))
                {
                    mainLocationQuery = mainLocationQuery.Until(new Expression()
                        .Where(new Expression()
                            .InE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)))
                    .Repeat(new Expression()
                        .InE(EdgeLabel.Belongs)
                        .OutV(VertexLabel.Location)
                        .Expression(ignoreLocationQuery)
                    );
                }

                if (!string.IsNullOrWhiteSpace(locationId))
                {
                    mainLocationQuery = mainLocationQuery
                    .InE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)
                    .Union(new Expression().OutV(VertexLabel.Person).Dedup(),
                        new Expression().OutV(VertexLabel.Company).InE(EdgeLabel.WorksAt).OutV(VertexLabel.Person).Dedup());
                }

                var attributeGroupQuery = (GraphQuery)new Expression();

                if (leadFilters.Contains(LeadFilter.AttributeGroup))
                {
                    attributeGroupQuery = new Expression()
                                .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
                                .InV(VertexLabel.Attribute)
                                .Dedup()
                                .OutE(EdgeLabel.Belongs)
                                .Dedup()
                                .InV(VertexLabel.AttributeGroup)
                                .Dedup()
                                .InE(EdgeLabel.Belongs)
                                .Dedup()
                                .OutV(VertexLabel.Attribute)
                                .Dedup()
                                .InE(EdgeLabel.Is, EdgeLabel.Mentions)
                                .OutV(VertexLabel.Person)
                                .Dedup();
                }

                var unindexedQuery = (GraphQuery)new Expression();

                if (leadFilters.Contains(LeadFilter.Unindexed))
                {
                    unindexedQuery = new Expression()
                                .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
                                .InV(VertexLabel.Attribute)
                                .Dedup()
                                .Not(new Expression()
                                    .OutE(EdgeLabel.Belongs))
                                .InE(EdgeLabel.Is, EdgeLabel.Mentions)
                                .OutV(VertexLabel.Person)
                                .Dedup();
                }

                var query = new GraphQuery()
                    .Expression(mainLocationQuery)
                    .Not(new Expression()
                        .Or(new Expression()
                                .Values(nameof(Vertex.Id).ToLower())
                                .Is(new Expression().Eq(personVertexId)),
                            new Expression()
                            .OutE(EdgeLabel.WorksIn)
                            .InV(VertexLabel.Company)
                            .InE(EdgeLabel.WorksIn).Count().Is(new Expression()
                                                                .Gt(1)),
                            new Expression()
                                .Where(new Expression()
                                    .InE(EdgeLabel.Lead)
                                    .OutV(VertexLabel.Person)
                                    .Has(nameof(Vertex.Id).ToLower(), personVertexId))))
                    .Where(new Expression()
                        .And(
                            notInLocationQuery,
                            unindexedQuery,
                            attributeGroupQuery,
                            new Expression()
                                .Where(new Expression()
                                    .Or(
                                        new Expression().InE(EdgeLabel.Lead).Count().Is(new Expression().Eq(0)),
                                        //new Expression().Not(new Expression().InE(EdgeLabel.Lead)),
                                        new Expression().And(
                                            new Expression()
                                                .InE(EdgeLabel.Lead)
                                                .Values(nameof(LeadEdge.CreatedAt))
                                                .Is(new Expression()
                                                    .Gt((DateTime.UtcNow.AddDays(-90)).Ticks)),
                                            new Expression()
                                                .InE(EdgeLabel.Lead)
                                                .OutV(VertexLabel.Person)
                                                .Has(nameof(Vertex.Id).ToLower().ToString(), personVertexId),
                                            new Expression()
                                                .Where(new Expression()
                                                    .Or(
                                                        new Expression().InE(EdgeLabel.Accepted, EdgeLabel.AutoDeclined,EdgeLabel.Declined, 
                                                                             EdgeLabel.Skipped, EdgeLabel.Referred)
                                                                        .Count()
                                                                        .Is(new Expression().Eq(0)),
                                                        //.Not(new Expression().InE(EdgeLabel.Accepted, EdgeLabel.AutoDeclined,
                                                        //    EdgeLabel.Declined, EdgeLabel.Skipped, EdgeLabel.Referred)),
                                                        new Expression()
                                                            .InE(EdgeLabel.Accepted, EdgeLabel.AutoDeclined, EdgeLabel.Declined,
                                                                EdgeLabel.Skipped, EdgeLabel.Referred)
                                                            .Values(nameof(StandardEdge.CreatedAt))
                                                            .Is(new Expression()
                                                                .Gt(DateTime.UtcNow.AddYears(-1).Ticks))))
                                            )
                                        )
                                    )   
                            )
                    )
                    .Dedup()
                    .Values(nameof(Vertex.Id).ToLower());

                if (limit.HasValue && leadFilters.Contains(LeadFilter.Country20))
                {
                    query = query.Limit(limit.Value);
                }

                var result = await gremlin.ExecuteQueryAsync<string>(query);

                //var result = await gremlin.ExecuteQueryAsync<dynamic>(query);

                return result;
            }
        }

        public async Task<IEnumerable<PersonDnaLeadsDTO>> GetMidnightPersonsAsync()
        {
            //var now = DateTime.UtcNow;
            //var midnightTomorrow = DateTime.UtcNow.Date.AddDays(1);
            //var midnightToday = DateTime.UtcNow.Date;
            //var minutesTomorrow = (midnightTomorrow - now).TotalMinutes;
            //var minutesToday = (midnightToday - now).TotalMinutes;

            //using (var gremlin = GremlinEngine.GetInstance())
            //{
            //    var query = new GraphQuery()
            //        .V(VertexLabel.Person)
            //        //.Has(nameof(Person.IsLocked), false.ToString())
            //        .Or(new Expression().Has(nameof(Person.UtcOffset), new Expression().Between(minutesToday, minutesToday + 60)),
            //            new Expression().Has(nameof(Person.UtcOffset), new Expression().Between(minutesTomorrow, minutesTomorrow + 60)))
            //        .As(nameof(PersonDnaLeadsDTO.PersonVertexId))
            //        .As(nameof(PersonDnaLeadsDTO.PersonProspexId))
            //        .OutE(EdgeLabel.Has)
            //        .InV(VertexLabel.DNA)
            //        .As(nameof(PersonDnaLeadsDTO.DnaRDL))
            //        .As(nameof(PersonDnaLeadsDTO.NumberOfLeads))
            //        .Select(nameof(PersonDnaLeadsDTO.PersonVertexId),
            //            nameof(PersonDnaLeadsDTO.PersonProspexId),
            //            nameof(PersonDnaLeadsDTO.DnaRDL),
            //            nameof(PersonDnaLeadsDTO.NumberOfLeads))
            //        .ByOrEmpty(nameof(Vertex.Id).ToLower())
            //        .ByOrEmpty(nameof(Person.ProspexId))
            //        .ByOrZero(nameof(Dna.RDL))
            //        .By(new Expression()
            //            .OutE(EdgeLabel.Lead)
            //            .Not(new Expression().Has(nameof(LeadEdge.DeliveryStatus), ((int)DeliveryStatus.Delivered).ToString()))
            //            .Count());

            //    var result = await gremlin.ExecuteQueryAsync<PersonDnaLeadsDTO>(query);

            //    return result.Where(x => x.DnaRDL > 0);
            //}

            using(var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .As(nameof(PersonDnaLeadsDTO.PersonVertexId))
                    .As(nameof(PersonDnaLeadsDTO.PersonProspexId))
                    .OutE(EdgeLabel.Has)
                    .InV(VertexLabel.DNA)
                    .As(nameof(PersonDnaLeadsDTO.DnaRDL))
                    //.As(nameof(PersonDnaLeadsDTO.NumberOfLeads))
                    .Select(nameof(PersonDnaLeadsDTO.PersonVertexId),
                        nameof(PersonDnaLeadsDTO.PersonProspexId),
                        nameof(PersonDnaLeadsDTO.DnaRDL))
                        //nameof(PersonDnaLeadsDTO.NumberOfLeads))
                    .ByOrEmpty(nameof(Vertex.Id).ToLower())
                    .ByOrEmpty(nameof(Person.ProspexId))
                    .ByOrZero(nameof(Dna.RDL));

                var result = await gremlin.ExecuteQueryAsync<PersonDnaLeadsDTO>(query);
                return result.Where(x => x.DnaRDL > 0);
            }
        }

        #region Private Methods

        private async Task CreateOrUpdateAverageReinforcementAsync(Vertex dnaVertex, Vertex attributeVertex, ReinforcementType reinforcementType, string originId, Source source, bool updateOnly)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var averageAttributeEdge = new AttributeEdge(EdgeLabel.Average, source, originId);

                var query = new GraphQuery()
                    .V().WithId(dnaVertex.GetId())
                    .OutE(EdgeLabel.Average)
                    .Where(new Expression().InV().WithId(attributeVertex.GetId()));

                if (updateOnly)
                {
                    var baseEdge = await gremlin.GetEdgeAsync(dnaVertex, attributeVertex, EdgeLabel.Average);

                    if (baseEdge != null)
                    {
                        var attributeEdge = EntityMapper.GetAttributeEdge(baseEdge);

                        query = query.Property(nameof(AttributeEdge.Reinforcement),
                                (attributeEdge.Reinforcement + reinforcementType.Value()).ToString(),
                                false);

                        await gremlin.ExecuteQueryAsync(query);
                    }
                }
                else
                {
                    var baseEdge = await gremlin.AddOrUpdateEdgeAsync(dnaVertex.Id, attributeVertex.Id, averageAttributeEdge);
                    var attributeEdge = EntityMapper.GetAttributeEdge(baseEdge);

                    query = query.Property(nameof(AttributeEdge.Reinforcement),
                            (attributeEdge.Reinforcement + reinforcementType.Value()).ToString(),
                            false);

                    await gremlin.ExecuteQueryAsync(query);
                }
            }
        }

        private async Task AddEmploymentsAsync(EmploymentHistory employmentHistory, Vertex person, Source source)
        {
            foreach (var employment in employmentHistory.EmploymentList)
            {
                await AddEmploymentAsync(employment, person, source);
            }
        }

        private async Task AddEmploymentAsync(Employment employment, Vertex personVertex, Source source)
        {
            await AddCompanyAsync(employment, personVertex, source);

            await AddEmploymentRoleAsync(employment, personVertex, source);
        }

        private async Task AddEmploymentRoleAsync(Employment employment, Vertex personVertex, Source source)
        {
            if (!employment.Role.HasValue)
            {
                await Task.CompletedTask;
                return;
            }

            var attributeEntity = new EmploymentAttributeEntity(employment.Role.Value.Title ?? "Unknown");

            if (employment.From.HasValue)
            {
                attributeEntity.EmploymentFromDate = employment.From.Value.Ticks;
            }

            if (employment.To.HasValue)
            {
                attributeEntity.EmploymentToDate = employment.To.Value.Ticks;
            }

            await _attributeRepository.AddAttributeIfNotExistsAsync(new AttributeDTO
            {
                Attribute = attributeEntity,
                Group = new AttributeGroupEntity(AttributeGroup.Role?.Value),
                Edge = new AttributeEdge(EdgeLabel.Is, source, personVertex.Id),
                SourceVertexId = personVertex.Id
            });
        }

        private async Task AddCompanyAsync(Employment employment, Vertex personVertex, Source source)
        {
            if (!employment.Company.HasValue)
            {
                await Task.CompletedTask;
                return;
            }

            var strategy = CompanyVertexResolutionStrategy.For(employment.Company.Value, source);
            var companyVertex = await strategy.AddOrUpdateAsync(employment.Company.Value);

            var workEdge = new WorkEdge(EdgeLabel.WorksAt, source)
            {
                Title = employment.Role.Value?.Title,
                IsValid = employment.IsPrimary,
                IsPrimary = employment.IsPrimary
            };

            if (employment.From.HasValue)
                workEdge.EmploymentFromDate = employment.From.Value.Ticks;

            if (employment.To.HasValue)
                workEdge.EmploymentToDate = employment.To.Value.Ticks;

            using (var gremlin = GremlinEngine.GetInstance())
            {
                await gremlin.AddOrUpdateEdgeAsync(personVertex.Id, companyVertex.Id, workEdge);
            }
        }

        private async Task AddSkillsAsync(Skills skills, Vertex personVertex, Source source)
        {
            var attributeGroupEntity = new AttributeGroupEntity(AttributeGroup.Skill?.Value);

            await _attributeRepository.AddAttributesIfNotExistsAsync(skills.Values.Select(x => x ?? "Unknown").Select(x =>
                new AttributeDTO
                {
                    Attribute = new AttributeEntity(x),
                    Group = attributeGroupEntity,
                    SourceVertexId = personVertex.Id,
                    Edge = new AttributeEdge(EdgeLabel.Is, source, personVertex.Id)
                }));
        }

        private async Task AddEducationHistoryAsync(EducationInfoHistory educationHistory, Vertex personVertex, Source source)
        {
            var attributeGroupEntity = new AttributeGroupEntity(AttributeGroup.Education?.Value);

            await _attributeRepository.AddAttributesIfNotExistsAsync(educationHistory.EducationList.SelectMany(x => x.Subjects).Select(x =>
               new AttributeDTO
               {
                   Attribute = new AttributeEntity(x ?? "Unknown"),
                   Group = attributeGroupEntity,
                   SourceVertexId = personVertex.Id,
                   Edge = new AttributeEdge(EdgeLabel.Is, source, personVertex.Id)
               }));
        }

        private async Task AddLocationsAsync(PersonLocation personLocation, Vertex personVertex, Source source)
        {
            foreach (var item in personLocation.All)
            {
                if (item.HasValue)
                {
                    await _locationRepository.AddAsync(item.Value, EdgeLabel.In, personVertex.Id, source);
                }
            }
            await Task.CompletedTask;
        }

        private async Task AddOccupationsAsync(Occupations occupations, Vertex personVertex, Source source)
        {
            var attributeGroupEntity = new AttributeGroupEntity(AttributeGroup.Occupation?.Value);

            await _attributeRepository.AddAttributesIfNotExistsAsync(occupations.Values.Select(x => GetPostnominal(x) ?? "Unknown").Select(x =>
               new AttributeDTO
               {
                   Attribute = new AttributeEntity(x),
                   Group = attributeGroupEntity,
                   SourceVertexId = personVertex.Id,
                   Edge = new AttributeEdge(EdgeLabel.Is, source, personVertex.Id)
               }));
        }

        private static string GetPostnominal(string str1)
        {
            var postnominal = _dictionary.FirstOrDefault(x => RawInBoundary(str1, x.Item2));

            var postnominalText = postnominal != null ? str1.ToLowerInvariant().Replace(postnominal.Item2.ToLowerInvariant(), postnominal.Item1) : str1;

            return postnominalText;
        }

        private static bool RawInBoundary(string str1, string str2) => Regex.Match(str1, $@"\b{str2}\b", RegexOptions.IgnoreCase).Success;

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

        //public async Task DeleteNonDeliveredLeadsAsync(string personVertexId)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var query = new GraphQuery()
        //            .V(VertexLabel.Person)
        //            .Has(nameof(Vertex.Id).ToLower(), personVertexId)
        //            .OutE(EdgeLabel.Lead)
        //            .Has(nameof(LeadEdge.DeliveryStatus), ((int)DeliveryStatus.Undelivered).ToString())
        //            .Drop();

        //        await gremlin.ExecuteQueryAsync(query);
        //    }
        //}

        //public async Task<List<LeadQueueDTO>> GetMarkedForDeliveryLeadsAsync(string personVertexId)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var query = new GraphQuery()
        //            .V(VertexLabel.Person)
        //            .Has(nameof(Vertex.Id).ToLower(), personVertexId)
        //            .OutE(EdgeLabel.Lead)
        //            .Has(nameof(LeadEdge.DeliveryStatus), ((int)DeliveryStatus.MarkForDelivery).ToString())
        //            .InV(VertexLabel.Person)
        //            .As(nameof(LeadQueueDTO.BirthdayLong),
        //                nameof(LeadQueueDTO.CrunchbaseUrl),
        //                nameof(LeadQueueDTO.Email2Address),
        //                nameof(LeadQueueDTO.Email3Address),
        //                nameof(LeadQueueDTO.EmailAddress),
        //                nameof(LeadQueueDTO.FacebookUrl),
        //                nameof(LeadQueueDTO.FirstName),
        //                nameof(LeadQueueDTO.Gender),
        //                nameof(LeadQueueDTO.GenerationDateLong),
        //                nameof(LeadQueueDTO.GenericJobTitle),
        //                nameof(LeadQueueDTO.Hobby),
        //                nameof(LeadQueueDTO.HomeAddressPoBox),
        //                nameof(LeadQueueDTO.HomeCity),
        //                nameof(LeadQueueDTO.HomeCountryRegion),
        //                nameof(LeadQueueDTO.HomeFax),
        //                nameof(LeadQueueDTO.HomePhone),
        //                nameof(LeadQueueDTO.HomePhone2),
        //                nameof(LeadQueueDTO.HomePostalCode),
        //                nameof(LeadQueueDTO.HomeState),
        //                nameof(LeadQueueDTO.HomeStreet),
        //                nameof(LeadQueueDTO.HomeStreet2),
        //                nameof(LeadQueueDTO.HomeStreet3),
        //                nameof(LeadQueueDTO.JobTitle),
        //                nameof(LeadQueueDTO.Keywords),
        //                nameof(LeadQueueDTO.Language),
        //                nameof(LeadQueueDTO.LastName),
        //                nameof(LeadQueueDTO.LinkedInUrl),
        //                nameof(LeadQueueDTO.LomiId),
        //                nameof(LeadQueueDTO.MiddleName),
        //                nameof(LeadQueueDTO.MobilePhone),
        //                nameof(LeadQueueDTO.PrimaryPhone),
        //                nameof(LeadQueueDTO.ProfileImage),
        //                nameof(LeadQueueDTO.Skype),
        //                nameof(LeadQueueDTO.TwitterUrl)
        //            )
        //            .Optional(new Expression()
        //                .OutE(EdgeLabel.WorksAt)
        //                .InV(VertexLabel.Company))
        //            .As(nameof(LeadQueueDTO.BusinessAddressPoBox),
        //                nameof(LeadQueueDTO.BusinessCity),
        //                nameof(LeadQueueDTO.BusinessCountryRegion),
        //                nameof(LeadQueueDTO.BusinessFax),
        //                nameof(LeadQueueDTO.BusinessLogo),
        //                nameof(LeadQueueDTO.BusinessName),
        //                nameof(LeadQueueDTO.BusinessPhone),
        //                nameof(LeadQueueDTO.BusinessPhone2),
        //                nameof(LeadQueueDTO.BusinessPostalCode),
        //                nameof(LeadQueueDTO.BusinessState),
        //                nameof(LeadQueueDTO.BusinessStreet),
        //                nameof(LeadQueueDTO.BusinessStreet2),
        //                nameof(LeadQueueDTO.BusinessStreet3),
        //                nameof(LeadQueueDTO.Categories),
        //                nameof(LeadQueueDTO.Company),
        //                nameof(LeadQueueDTO.CompanyMainPhone))
        //            .Select(nameof(LeadQueueDTO.BirthdayLong),
        //                nameof(LeadQueueDTO.CrunchbaseUrl),
        //                nameof(LeadQueueDTO.Email2Address),
        //                nameof(LeadQueueDTO.Email3Address),
        //                nameof(LeadQueueDTO.EmailAddress),
        //                nameof(LeadQueueDTO.FacebookUrl),
        //                nameof(LeadQueueDTO.FirstName),
        //                nameof(LeadQueueDTO.Gender),
        //                nameof(LeadQueueDTO.GenerationDateLong),
        //                nameof(LeadQueueDTO.GenericJobTitle),
        //                nameof(LeadQueueDTO.Hobby),
        //                nameof(LeadQueueDTO.HomeAddressPoBox),
        //                nameof(LeadQueueDTO.HomeCity),
        //                nameof(LeadQueueDTO.HomeCountryRegion),
        //                nameof(LeadQueueDTO.HomeFax),
        //                nameof(LeadQueueDTO.HomePhone),
        //                nameof(LeadQueueDTO.HomePhone2),
        //                nameof(LeadQueueDTO.HomePostalCode),
        //                nameof(LeadQueueDTO.HomeState),
        //                nameof(LeadQueueDTO.HomeStreet),
        //                nameof(LeadQueueDTO.HomeStreet2),
        //                nameof(LeadQueueDTO.HomeStreet3),
        //                nameof(LeadQueueDTO.JobTitle),
        //                nameof(LeadQueueDTO.Keywords),
        //                nameof(LeadQueueDTO.Language),
        //                nameof(LeadQueueDTO.LastName),
        //                nameof(LeadQueueDTO.LinkedInUrl),
        //                nameof(LeadQueueDTO.LomiId),
        //                nameof(LeadQueueDTO.MiddleName),
        //                nameof(LeadQueueDTO.MobilePhone),
        //                nameof(LeadQueueDTO.PrimaryPhone),
        //                nameof(LeadQueueDTO.ProfileImage),
        //                nameof(LeadQueueDTO.Skype),
        //                nameof(LeadQueueDTO.TwitterUrl),
        //                nameof(LeadQueueDTO.BusinessAddressPoBox),
        //                nameof(LeadQueueDTO.BusinessCity),
        //                nameof(LeadQueueDTO.BusinessCountryRegion),
        //                nameof(LeadQueueDTO.BusinessFax),
        //                nameof(LeadQueueDTO.BusinessLogo),
        //                nameof(LeadQueueDTO.BusinessName),
        //                nameof(LeadQueueDTO.BusinessPhone),
        //                nameof(LeadQueueDTO.BusinessPhone2),
        //                nameof(LeadQueueDTO.BusinessPostalCode),
        //                nameof(LeadQueueDTO.BusinessState),
        //                nameof(LeadQueueDTO.BusinessStreet),
        //                nameof(LeadQueueDTO.BusinessStreet2),
        //                nameof(LeadQueueDTO.BusinessStreet3),
        //                nameof(LeadQueueDTO.Categories),
        //                nameof(LeadQueueDTO.Company),
        //                nameof(LeadQueueDTO.CompanyMainPhone)
        //            )
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Birthdate)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.CrunchbaseUrl)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Email2)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Email3)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Email)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.FacebookUrl)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.FirstName)))
        //            .By(new Expression()
        //                .OutE(EdgeLabel.Is)
        //                .InV(VertexLabel.Attribute)
        //                .Where(new Expression()
        //                    .OutE(EdgeLabel.Belongs)
        //                    .InV(VertexLabel.AttributeGroup)
        //                    .Has(nameof(AttributeGroupEntity.Value), nameof(AttributeGroup.Gender)))
        //                .ValuesOrEmpty(nameof(AttributeEntity.Value)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Vertex.CreatedAt)))
        //            .By(new Expression().Coalesce(
        //                new Expression().OutE(EdgeLabel.WorksAt).ValuesOrEmpty(nameof(WorkEdge.Title)),
        //                new Expression().Constant("")))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Hobby)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.AddressPoBox)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.City)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Country)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Fax)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Phone)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Phone2)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.PostalCode)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.State)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Street)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Street2)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Street3)))
        //            .By(new Expression().Coalesce(
        //                new Expression().OutE(EdgeLabel.WorksAt).ValuesOrEmpty(nameof(WorkEdge.Title)),
        //                new Expression().Constant("")))
        //            .By(new Expression()
        //                .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
        //                .InV(VertexLabel.Attribute)
        //                .Dedup()
        //                .Values(nameof(AttributeEntity.Value)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Language)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.LastName)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.LinkedInUrl)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Vertex.Id).ToLower()))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.MiddleName)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.MobilePhone)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.PrimaryPhone)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.PictureUrl)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.Skype)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Person.TwitterUrl)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.AddressPoBox)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.City)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Country)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Fax)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.LogoUrl)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Name)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Phone)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Phone2)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.PostalCode)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.State)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Street)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Street2)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Street3)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Categories)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Name)))
        //            .By(new Expression().ValuesOrEmpty(nameof(Company.Phone)));

        //        var result = await gremlin.ExecuteQueryAsync<LeadQueueDTO>(query);

        //        return result;
        //    }
        //}

        //public async Task<List<LeadGeneratorDTO>> GetPeopleWithMarkedForDeliveryLeadsAsync()
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var graphQuery = new GraphQuery()
        //            .V(VertexLabel.Person)
        //            .Where(new Expression()
        //                .OutE(EdgeLabel.Lead)
        //                .Has(nameof(LeadEdge.DeliveryStatus), ((int)DeliveryStatus.MarkForDelivery).ToString()))
        //            .As(nameof(LeadGeneratorDTO.PersonProspexId),
        //                nameof(LeadGeneratorDTO.PersonVertexId))
        //            .Select(nameof(LeadGeneratorDTO.PersonProspexId),
        //                nameof(LeadGeneratorDTO.PersonVertexId))
        //            .ByOrEmpty(nameof(Person.ProspexId))
        //            .ByOrEmpty(nameof(Vertex.Id).ToLower());

        //        return await gremlin.ExecuteQueryAsync<LeadGeneratorDTO>(graphQuery);
        //    }
        //}

        //public async Task<List<LeadDTO>> GetExistingLeadsAsync(string personVertexId)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var query = new GraphQuery()
        //            .V(VertexLabel.Person)
        //            .Has(nameof(Vertex.Id).ToLower(), personVertexId)
        //            .OutE(EdgeLabel.Accepted, EdgeLabel.Declined, EdgeLabel.Referred, EdgeLabel.AutoDeclined)
        //            .OrderByDecr(nameof(StandardEdge.UpdatedAt))
        //            .Limit(1)
        //            .As(nameof(LeadDTO.Accepted),
        //                nameof(LeadDTO.UpdatedAt))
        //            .Select(nameof(LeadDTO.Accepted),
        //                nameof(LeadDTO.UpdatedAt))
        //            .By(new Expression()
        //                .Choose(new Expression().Values(nameof(Vertex.Label).ToLower()),
        //                        new Expression().Constant(true),
        //                        new Expression().Constant(false)))
        //            .By(nameof(StandardEdge.UpdatedAt));

        //        return await gremlin.ExecuteQueryAsync<LeadDTO>(query);
        //    }
        //}

        //public async Task<List<string>> GetLeadsAsync(string personVertexId, List<LeadFilter> leadFilters, string locationId = null, string ignoreLocationId = null, int? limit = null)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var mainLocationQuery = locationId == null ? new Expression().V(VertexLabel.Person)
        //            : new Expression().V(VertexLabel.Location).Has(nameof(Vertex.Id).ToLower(), locationId);

        //        var ignoreLocationQuery = ignoreLocationId == null ? null
        //            : new Expression().Not(new Expression().Has(nameof(Vertex.Id).ToLower().ToString(), ignoreLocationId));

        //        var notInLocationQuery = ignoreLocationId == null ? null
        //            : new Expression()
        //                .OutE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)
        //                .InV(VertexLabel.Location)
        //                .Where(new Expression()
        //                .Until(new Expression()
        //                    .Where(new Expression()
        //                        .Has(nameof(Vertex.Id).ToLower(), ignoreLocationId)))
        //                .Repeat(new Expression()
        //                    .OutE(EdgeLabel.Belongs)
        //                    .InV(VertexLabel.Location)).Count().Is(new Expression().Eq(0)))
        //                .Count().Is(new Expression().Lt(1));

        //        if (leadFilters.Contains(LeadFilter.Country) ||
        //            leadFilters.Contains(LeadFilter.Country20) ||
        //            leadFilters.Contains(LeadFilter.City))
        //        {
        //            mainLocationQuery = mainLocationQuery.Until(new Expression()
        //                .Where(new Expression()
        //                    .InE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)))
        //            .Repeat(new Expression()
        //                .InE(EdgeLabel.Belongs)
        //                .OutV(VertexLabel.Location)
        //                .Expression(ignoreLocationQuery)
        //            );
        //        }

        //        if (!string.IsNullOrWhiteSpace(locationId))
        //        {
        //            mainLocationQuery = mainLocationQuery
        //            .InE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)
        //            .Union(new Expression().OutV(VertexLabel.Person).Dedup(),
        //                new Expression().OutV(VertexLabel.Company).InE(EdgeLabel.WorksAt).OutV(VertexLabel.Person).Dedup());
        //        }

        //        var attributeGroupQuery = (GraphQuery)new Expression();

        //        if (leadFilters.Contains(LeadFilter.AttributeGroup))
        //        {
        //            attributeGroupQuery = new Expression()
        //                        .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
        //                        .InV(VertexLabel.Attribute)
        //                        .Dedup()
        //                        .OutE(EdgeLabel.Belongs)
        //                        .Dedup()
        //                        .InV(VertexLabel.AttributeGroup)
        //                        .Dedup()
        //                        .InE(EdgeLabel.Belongs)
        //                        .Dedup()
        //                        .OutV(VertexLabel.Attribute)
        //                        .Dedup()
        //                        .InE(EdgeLabel.Is, EdgeLabel.Mentions)
        //                        .OutV(VertexLabel.Person)
        //                        .Dedup();
        //        }

        //        var unindexedQuery = (GraphQuery)new Expression();

        //        if (leadFilters.Contains(LeadFilter.Unindexed))
        //        {
        //            unindexedQuery = new Expression()
        //                        .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
        //                        .InV(VertexLabel.Attribute)
        //                        .Dedup()
        //                        .Not(new Expression()
        //                            .OutE(EdgeLabel.Belongs))
        //                        .InE(EdgeLabel.Is, EdgeLabel.Mentions)
        //                        .OutV(VertexLabel.Person)
        //                        .Dedup();
        //        }

        //        var query = new GraphQuery()
        //            .Expression(mainLocationQuery)
        //            .Not(new Expression()
        //                .Or(new Expression()
        //                        .Values(nameof(Vertex.Id).ToLower())
        //                        .Is(new Expression().Eq(personVertexId)),
        //                    new Expression()
        //                        .Where(new Expression()
        //                            .InE(EdgeLabel.Lead)
        //                            .OutV(VertexLabel.Person)
        //                            .Has(nameof(Vertex.Id).ToLower(), personVertexId))))
        //            .Where(new Expression()
        //                .And(
        //                    notInLocationQuery,
        //                    unindexedQuery,
        //                    attributeGroupQuery,
        //                    new Expression()
        //                        .Where(new Expression()
        //                            .Or(new Expression().Not(new Expression().InE(EdgeLabel.Lead)),
        //                                new Expression().And(
        //                                    new Expression()
        //                                        .InE(EdgeLabel.Lead)
        //                                        .Values(nameof(LeadEdge.CreatedAt))
        //                                        .Is(new Expression()
        //                                            .Gt((DateTime.UtcNow.AddDays(-90)).Ticks)),
        //                                    new Expression()
        //                                        .InE(EdgeLabel.Lead)
        //                                        .OutV(VertexLabel.Person)
        //                                        .Has(nameof(Vertex.Id).ToLower().ToString(), personVertexId),
        //                                    new Expression()
        //                                        .Where(new Expression()
        //                                            .Or(new Expression()
        //                                                    .Not(new Expression().InE(EdgeLabel.Accepted, EdgeLabel.AutoDeclined,
        //                                                        EdgeLabel.Declined, EdgeLabel.Skipped, EdgeLabel.Referred)),
        //                                                new Expression()
        //                                                    .InE(EdgeLabel.Accepted, EdgeLabel.AutoDeclined, EdgeLabel.Declined,
        //                                                        EdgeLabel.Skipped, EdgeLabel.Referred)
        //                                                    .Values(nameof(StandardEdge.CreatedAt))
        //                                                    .Is(new Expression()
        //                                                        .Gt(DateTime.UtcNow.AddYears(-1).Ticks))))
        //                                )
        //                            )
        //                        )
        //                )
        //            )
        //            .Dedup()
        //            .Values(nameof(Vertex.Id).ToLower());

        //        if (limit.HasValue && leadFilters.Contains(LeadFilter.Country20))
        //        {
        //            query = query.Limit(limit.Value);
        //        }

        //        var result = await gremlin.ExecuteQueryAsync<string>(query);

        //        return result;
        //    }
        //}

        //public async Task<bool> DeactivateOnboardingAttributesAsync(string prospexId)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var query = new GraphQuery()
        //            .V(VertexLabel.Person)
        //            .Has(nameof(Person.ProspexId), prospexId)
        //            .OutE(EdgeLabel.Has)
        //            .InV(VertexLabel.DNA)
        //            .OutE(EdgeLabel.Is, EdgeLabel.Mentions)
        //            .Has(nameof(AttributeEdge.Source), Source.Onboarding.Value)
        //            // TODO: Possibly not necessary
        //            //.Where(new Expression().LessThan(nameof(AttributeEdge.UpdatedAt), DateTime.UtcNow.Date.Ticks))
        //            .Property(nameof(AttributeEdge.IsActive), false.ToString(), false);

        //        var result = await gremlin.ExecuteQueryAsync<BaseEdge>(query);

        //        return result?.Any() ?? false;
        //    }
        //}

        //public async Task<Vertex> AddPersonAsync(string salesForceId, Person person, EdgeLabel edgeLabel, Source source)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var strategy = CompanyVertexResolutionStrategy.ForSalesForce(salesForceId);
        //        var companyVertex = await strategy.GetVertexAsync(gremlin);

        //        if (companyVertex.HasValue)
        //        {
        //            Vertex pesonVertex = await AddPersonAsync(person, source);
        //            var edge = new StandardEdge(edgeLabel);
        //            //edge.IsDirty = true;

        //            await gremlin.AddEdgeAsync(edge, companyVertex.Value, pesonVertex);

        //            return pesonVertex;
        //        }
        //    }
        //    return null;
        //}

        //public async Task AddPersonAsync(string salesForceId, Person person, Source source)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var strategy = CompanyVertexResolutionStrategy.ForSalesForce(salesForceId);
        //        var companyVertex = await strategy.GetVertexAsync(gremlin);
        //        if (companyVertex.HasValue)
        //        {
        //            Vertex pesonVertex = await AddPersonAsync(person, source);

        //            await gremlin.AddEdgeAsync(new StandardEdge(EdgeLabel.Employer), companyVertex.Value, pesonVertex);
        //        }
        //    }
        //}

        //public async Task<Vertex> AddPersonAsync(VertexId id, Person person, EdgeLabel edgeLabel, Source source)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var strategy = new VertexIdResolutionStrategy(VertexLabel.Company, id);
        //        var companyVertex = await strategy.GetVertexAsync(gremlin);

        //        if (companyVertex.HasValue)
        //        {
        //            Vertex personVertex = await AddPersonAsync(person, source);

        //            await gremlin.AddEdgeAsync(new StandardEdge(edgeLabel), personVertex, companyVertex.Value);

        //            return personVertex;
        //        }
        //    }
        //    return null;
        //}

        //public async Task<Vertex> AddPersonAsync(Person person, IEnumerable<Person> friends, Source source)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        // TODO optimize for relationship between same persons
        //        Vertex personVertex = await AddPersonAsync(person, source);

        //        //await CopyAttributesFromPersonToDna(person.ProspexId);

        //        var friendsVertices = new List<Vertex>();
        //        foreach (var friend in friends)
        //        {
        //            var friendVertex = await AddPersonAsync(friend, source);
        //            await gremlin.AddEdgeAsync(new StandardEdge(EdgeLabel.Friend), personVertex, friendVertex);

        //            if (source == Source.Facebook)
        //            {
        //                //await UpdateAttributesFromReinforcementToDna(person.ProspexId,
        //                //    ReinforcementType.FacebookValid, friendVertex.Id, EdgeLabel.Friend);
        //            }
        //        }

        //        return personVertex;
        //    }
        //}

        //public async Task<Vertex> AddPersonAsync(Person person, Source source)
        //{
        //    using (var gremlin = GremlinEngine.GetInstance())
        //    {
        //        var strategy = PersonVertexResolutionStrategy.For(person);
        //        var personVertex = await strategy.GetVertexAsync(gremlin);

        //        if (!personVertex.HasValue)
        //        {
        //            personVertex = Maybe.Some(await gremlin.AddVertexAsync(VertexLabel.Person, person));
        //        }
        //        else
        //        {
        //            await gremlin.UpdateVertexPropertiesAsync(VertexLabel.Person, personVertex.Value.GetId(), person);
        //        }

        //        person.Attributes.Add(AttributeGroup.Age, person.AgeCategory.ToFriendlyString());
        //        person.Attributes.Add(AttributeGroup.Gender, person.Gender.ToString());

        //        await AddEmploymentsAsync(person.EmploymentHistory, personVertex.Value, source);

        //        await AddLocationsAsync(person.Location, personVertex.Value, source);

        //        await AddOccupationsAsync(person.Occupations, personVertex.Value, source);

        //        await AddSkillsAsync(person.Skills, personVertex.Value, source);

        //        await AddEducationHistoryAsync(person.EducationList, personVertex.Value, source);

        //        return personVertex.Value;
        //    }
        //}
    }
}