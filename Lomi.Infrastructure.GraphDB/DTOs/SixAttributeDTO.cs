using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class SixAttributeDTO
    {
        public string AttributeVertexId { get; set; }
        public double Confidence { get; set; }
        public double Weight { get; set; }
        public long LastRefreshedAt { get; set; }
    }
}