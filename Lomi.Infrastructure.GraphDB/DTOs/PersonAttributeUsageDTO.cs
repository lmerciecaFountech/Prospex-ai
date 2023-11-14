using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class PersonAttributeUsageDTO
    {
        public string PersonVertexId { get; set; }
        public string AttributeVertexId { get; set; }
        public double AttributeAverageWeight { get; set; }
        public long AttributeCreatedAt { get; set; }
    }
}