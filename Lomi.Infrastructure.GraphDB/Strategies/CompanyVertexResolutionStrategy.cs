using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Strategies
{
    public class CompanyVertexResolutionStrategy : IVertexResolutionStrategy
    {
        #region Members

        private string _sourceId;
        private Source _source;
        private string _prospexId;
        private string _geolocation;
        private string _locationName;
        private string _name;
        private string _id;

        #endregion

        public static CompanyVertexResolutionStrategy For(Company company, Source source)
        {
            return new CompanyVertexResolutionStrategy
            {
                _sourceId = company.SourceId,
                _source = source,
                _prospexId = company.ProspexId,
                _geolocation = company.Geolocation,
                _locationName = company.LocationName,
                _name = company.Name,
                _id = company.Id
            };
        }

        public static CompanyVertexResolutionStrategy ForId(string id)
        {
            return new CompanyVertexResolutionStrategy
            {
                _id = id
            };
        }

        public static CompanyVertexResolutionStrategy ForProspexId(string prospexId)
        {
            return new CompanyVertexResolutionStrategy
            {
                _prospexId = prospexId
            };
        }

        public async Task<Vertex> AddOrUpdateAsync(Entity entity)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var possibleVertex = await gremlin.AddOrUpdateVertexAsync(this, VertexLabel.Company, entity);
                return possibleVertex.Value;
            }
        }

        public async Task<Maybe<Vertex>> GetAsync()
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var graphQuery = GetQuery();

                return graphQuery.HasValue
                    ? Maybe.Some((await gremlin.ExecuteQueryFirstAsync<Vertex>(graphQuery.Value)).Value)
                    : Maybe<Vertex>.None;
            }
        }

        public Maybe<GraphQuery> GetQuery()
        {
            var query = new GraphQuery().V(VertexLabel.Company);

            var expressions = new List<GraphQuery>();

            if (!string.IsNullOrWhiteSpace(_id))
            {
                expressions.Add(new Expression().Has(nameof(Company.Id).ToLower(), _id));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(_sourceId) && _source != null)
                {
                    expressions.Add(new Expression().Has(nameof(Company.SourceId), _sourceId)
                        .And(new Expression()
                            .Properties(nameof(Company.SourceId))
                            .HasValue(_sourceId)
                            .Has(nameof(Source), _source.ToString())));
                }
                if (!string.IsNullOrWhiteSpace(_name))
                {
                    if (!string.IsNullOrWhiteSpace(_geolocation))
                    {
                        var e = new List<GraphQuery>
                        {
                            new Expression().Has(nameof(Company.Name), _name),
                            new Expression().Has(nameof(Company.Geolocation), _geolocation)
                        };

                        expressions.Add(new Expression().And(e.ToArray()));
                    }
                    else if (!string.IsNullOrWhiteSpace(_locationName))
                    {
                        var e = new List<GraphQuery>
                        {
                            new Expression().Has(nameof(Company.Name), _name),
                            new Expression().Has(nameof(Company.LocationName), _locationName),
                        };
                        expressions.Add(new Expression().And(e.ToArray()));
                    }
                }
            }

            return expressions.Any() 
                ? Maybe.Some(query.Or(expressions.ToArray())) 
                : Maybe<GraphQuery>.None;
        }
    }
}