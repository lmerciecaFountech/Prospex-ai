using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;

namespace Lomi.Infrastructure.GraphDB.Strategies
{
    public class AttributeGroupVertexResolutionStrategy : IVertexResolutionStrategy
    {
        private string _id;

        public static AttributeGroupVertexResolutionStrategy ForId(string id)
        {
            return new AttributeGroupVertexResolutionStrategy
            {
                _id = id
            };
        }

        public async Task<Vertex> AddOrUpdateAsync(Entity entity)
        {
            using(var gremlin = GremlinEngine.GetInstance())
            {
                var possibleVertex = await gremlin.AddOrUpdateVertexAsync(this, VertexLabel.AttributeGroup, entity);
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
            var query = new GraphQuery().V(VertexLabel.AttributeGroup);

            var expressions = new List<GraphQuery>();

            if (!string.IsNullOrWhiteSpace(_id))
            {
                expressions.Add(new Expression().Has(nameof(Entity.Id).ToLower(), _id));
            }

            return expressions.Any()
                ? Maybe.Some(query.Or(expressions.ToArray()))
                : Maybe<GraphQuery>.None;
        }
    }
}
