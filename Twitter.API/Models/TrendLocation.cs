using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.API.Models
{
    internal class TrendLocation
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public PlaceType PlaceType { get; set; }
        public string Url { get; set; }
        public int WoeID { get; set; }
    }

    internal class PlaceType
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
