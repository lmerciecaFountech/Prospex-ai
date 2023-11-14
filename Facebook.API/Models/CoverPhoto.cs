using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class CoverPhoto
    {
        public string Id { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public string Source { get; set; }
    }
}
