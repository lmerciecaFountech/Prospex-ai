using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Interfaces
{
    public interface IGraphLocationService
    {
        Task<Maybe<Vertex>> AddLocationAsync(Location location, Vertex vertex, Source source = null);
        Task<Location> GetLocationByPlaceIdAsync(string placeId);
        Task<CityCountryDTO> GetCityAndCountryAsync(string prospexId);
    }
}