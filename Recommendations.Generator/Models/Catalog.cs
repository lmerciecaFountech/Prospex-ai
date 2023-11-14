using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Generator.Models
{
    public class Catalog
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string Description { get; set; }
        public string FeaturesList { get; set; }
    }
}