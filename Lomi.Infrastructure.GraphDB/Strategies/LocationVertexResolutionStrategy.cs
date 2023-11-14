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
    public class LocationVertexResolutionStrategy : IVertexResolutionStrategy
    {
        private Location _location;

        private LocationVertexResolutionStrategy()
        {

        }

        public static LocationVertexResolutionStrategy For(Location location)
        {
            return new LocationVertexResolutionStrategy
            {
                _location = location
            };
        }

        public async Task<Vertex> AddOrUpdateAsync(Entity entity)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var possibleVertex = await gremlin.AddOrUpdateVertexAsync(this, VertexLabel.Location, entity);
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
            GraphQuery query = null;

            if (!string.IsNullOrEmpty(_location.PlaceId))
            {
                query = new GraphQuery().V(VertexLabel.Location).Has(nameof(Location.PlaceId), _location.PlaceId);
            }

            return query != null
                ? Maybe.Some(query)
                : Maybe<GraphQuery>.None;
        }
    }
}