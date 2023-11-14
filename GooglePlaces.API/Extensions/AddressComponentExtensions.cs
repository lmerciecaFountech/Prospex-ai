using GooglePlaces.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAPIAddressComponent = GoogleApi.Entities.Common.AddressComponent;

namespace GooglePlaces.API.Extensions
{
    public static class AddressComponentExtensions
    {
        public static IEnumerable<AddressComponent> DeepCopy(this IEnumerable<GoogleAPIAddressComponent> addressComponents) =>
            addressComponents.Select(DeepCopy);

        public static AddressComponent DeepCopy(this GoogleAPIAddressComponent addressComponent) =>
            new AddressComponent(addressComponent.LongName, addressComponent.ShortName, addressComponent.Types);
    }
}
