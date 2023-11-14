using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Generator.Models
{
    public class Keyword
    {
        public string Id { get; set; }
        public string Word { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string[]> Features { get; set; }
        public string Category { get; set; }
    }
}