using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Flight 
    {
        public string Id { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string OriginAirport { get; set; }
        public string OriginCity { get; set; }
        public string DestinationAirport { get; set; }
        public string DestinationCity { get; set; }
        public string Price { get; set; }
        public string FlightId { get; set; }
        public List<string> Images { get; set; }
        public List<string> SanitizedImages { get; set; }
        public string OnewayCurrency { get; set; }
        public string OnewayPrice { get; set; }
        public string Url { get; set; }
    }
}