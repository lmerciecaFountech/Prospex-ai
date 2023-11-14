using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAPIAddressComponentType = GoogleApi.Entities.Common.Enums.AddressComponentType;
using GooglePlaces.API.Extensions;
using GooglePlaces.API.Enums;

namespace GooglePlaces.API.Data
{
    public class AddressComponent
    {
        [JsonConstructor]
        public AddressComponent(string longName, string shortName, IEnumerable<GoogleAPIAddressComponentType> types)
        {
            LongName = longName;
            ShortName = shortName;
            Types = types.DeepCopy();
        }

        #region Properties

        public string LongName { get; set; }
        public string ShortName { get; set; }
        public IEnumerable<AddressComponentType> Types { get; set; }

        #endregion
    }
}
