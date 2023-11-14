using GooglePlaces.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAPIAddressComponentType = GoogleApi.Entities.Common.Enums.AddressComponentType;


namespace GooglePlaces.API.Extensions
{
    public static class AddressComponentTypeExtensions
    {
        public static List<AddressComponentType> DeepCopy(this IEnumerable<GoogleAPIAddressComponentType> addressComponentTypes) =>
            addressComponentTypes.Select(DeepCopy).ToList();

        public static AddressComponentType DeepCopy(this GoogleAPIAddressComponentType addressComponentType) =>
            (AddressComponentType)addressComponentType;
    }
}
