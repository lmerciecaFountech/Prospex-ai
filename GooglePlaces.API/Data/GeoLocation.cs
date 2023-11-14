using GooglePlaces.API.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAPIAddressComponent = GoogleApi.Entities.Common.AddressComponent;

namespace GooglePlaces.API.Data
{
    public class GeoLocation
    {
        [JsonConstructor]
        public GeoLocation(string placeId, double latitude, double longitude, int utcOffset, IEnumerable<GoogleAPIAddressComponent> addressComponents)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Longitude = longitude;
            UtcOffset = utcOffset;
            AddressComponents = addressComponents.DeepCopy().ToList();
        }

        #region Properties

        public int UtcOffset { get; set; }
        public string PlaceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<AddressComponent> AddressComponents { get; set; }

        #endregion

        public override int GetHashCode()
        {
            return PlaceId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var geolocation = obj as GeoLocation;

            return geolocation.PlaceId == PlaceId;
        }
    }
}
