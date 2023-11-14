using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Place
    {
        public string Id { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public double OverallRating { get; set; }
    }
}