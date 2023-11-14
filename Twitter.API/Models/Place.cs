using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.API.Models
{
    internal class Place
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string PlaceType { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public BoundingBox BoundingBox { get; set; }
        public string Attributes { get; set; }
    }

    internal class BoundingBox
    {
        public string Type { get; set; }
        public Coordinate[] Coordinates { get; set; }
    }

    internal class Coordinate
    {

    }
}
