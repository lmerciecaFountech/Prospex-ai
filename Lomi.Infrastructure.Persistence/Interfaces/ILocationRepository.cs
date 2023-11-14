using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Interfaces
{
    public interface ILocationRepository
    {
        Task<Maybe<Vertex>> AddAsync(Location location, EdgeLabel edgeLabel, string fromId, Source source = null);
        Task<CityCountryDTO> GetCityCountryAsync(string personVertexId);
        Task<Location> GetByPlaceIdAsync(string placeId);
    }
}