using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class GraphLocationService : IGraphLocationService
    {


        public GraphLocationService()
        {

        }

        public Task<Maybe<Vertex>> AddLocationAsync(Location location, Vertex vertex, Source source = null)
        {
            throw new NotImplementedException();
        }

        public Task<CityCountryDTO> GetCityAndCountryAsync(string prospexId)
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetLocationByPlaceIdAsync(string placeId)
        {
            throw new NotImplementedException();
        }
    }
}