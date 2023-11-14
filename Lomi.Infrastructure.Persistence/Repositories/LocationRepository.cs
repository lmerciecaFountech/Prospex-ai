using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
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
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : RepositoryBase, ILocationRepository
    {
        public async Task<Maybe<Vertex>> AddAsync(Location location, EdgeLabel edgelabel, string fromId, Source source = null)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                if (!location.CanBeAdded)
                    return Maybe<Vertex>.None;

                var strategy = LocationVertexResolutionStrategy.For(location);

                var locationVertex = await strategy.AddOrUpdateAsync(location);

                var standardEdge = new LocationEdge
                {
                    Label = edgelabel,
                    Source = source,
                    Order = edgelabel.LocationOrder(),
                    IsSelected = location.IsSelected()
                };

                await gremlin.AddOrUpdateEdgeAsync(fromId, locationVertex.Id, standardEdge);

                await Task.Delay(300);

                foreach (var parentLocation in location.Parents)
                {
                    await AddAsync(parentLocation, EdgeLabel.Belongs, locationVertex.Id, Source.Onboarding);
                }

                return Maybe.Some(locationVertex);
            }
        }

        public async Task<CityCountryDTO> GetCityCountryAsync(string personVertexId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Person)
                    .Has(nameof(Vertex.Id).ToLower(), personVertexId)
                    .OutE(EdgeLabel.WorksIn, EdgeLabel.LivesIn, EdgeLabel.In)
                    .InV(VertexLabel.Location)
                    .Dedup()
                    .Until(new Expression().Has(nameof(Location.LocationType), "Country"))
                    .Repeat(new Expression().OutE(EdgeLabel.Belongs).InV(VertexLabel.Location))
                    .As(nameof(CityCountryDTO.CountryId))
                    .Until(new Expression().Has(nameof(Location.LocationType), "Locality"))
                    .Repeat(new Expression().InE(EdgeLabel.Belongs).OutV(VertexLabel.Location))
                    .As(nameof(CityCountryDTO.CityId))
                    .Select(
                        nameof(CityCountryDTO.CountryId),
                        nameof(CityCountryDTO.CityId))
                    .By(nameof(Vertex.Id).ToLower())
                    .By(nameof(Vertex.Id).ToLower());

                var result = await gremlin.ExecuteQueryAsync<CityCountryDTO>(query);

                return result.FirstOrDefault();
            }
        }

        public async Task<Location> GetByPlaceIdAsync(string placeId)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var query = new GraphQuery()
                    .V(VertexLabel.Location)
                    .Has(nameof(Location.PlaceId), placeId);

                var location = await gremlin.ExecuteQueryFirstAsync<BaseVertex>(query);

                return !location.HasValue ? null : EntityMapper.GetLocation(location.Value);
            }
        }
    }
}