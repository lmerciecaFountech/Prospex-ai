using GooglePlaces.API.Data;
using GooglePlaces.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlaces.API.Extensions
{
    public static class GeoLocationExtensions
    {
        public static List<GeoLocation> WhereContainsCityAndCountry(this IEnumerable<GeoLocation> geoLocations) =>
            geoLocations.Where(gl => gl.AddressComponents.Any(ac => ac.Types.Any(t => t == AddressComponentType.Locality)) &&
                                     gl.AddressComponents.Any(ac => ac.Types.Any(t => t == AddressComponentType.Political || t == AddressComponentType.Country))).ToList();
    }
}
