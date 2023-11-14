using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class AttributeEdgeDTO
    {
        public string Id { get; set; }
        public int? Reinforcement { get; set; }
        public double Weight { get; set; }
        public double Confidence { get; set; }
        public long Gravity { get; set; }
        public long CreatedAt { get; set; }
        public string Source { get; set; }
        public double Multiplier { get; set; }
    }
}