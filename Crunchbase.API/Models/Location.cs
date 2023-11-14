using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/location
    /// </summary>
    internal sealed class Location : BaseModel
    {
        public string Name { get; set; }
        public string LocationType { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int RegionCode2 { get; set; }
        public string Country { get; set; }
        public int CountryCode2 { get; set; }
        public int CountryCode3 { get; set; }
    }
}