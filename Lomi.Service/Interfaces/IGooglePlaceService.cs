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
    public interface IGooglePlaceService
    {
        Task<List<Maybe<Location>>> GetLocationsAsync(string address, EdgeLabel label);
        Task<Maybe<Location>> GetLocationByPlaceIdAsync(string placeId, EdgeLabel label);
    }
}
