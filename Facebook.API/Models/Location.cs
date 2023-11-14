using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Location
    {
        public string City { get; set; }
        public int CityId { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public float Latitude { get; set; }
        public float Langitude { get; set; }
        public string LocatedIn { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}