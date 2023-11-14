using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class PlaceTopic
    {
        public string Id { get; set; }
        public int Count { get; set; }
        public bool HasChildren { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public List<string> TopSubtopicNames { get; set; }
        public List<int> ParentIds { get; set; }
    }
}