using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class PersonAttributeCatalogDTO
    {
        public string AttributeVertexId { get; set; }
        public double AttributeAverageWeight { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeInfoBoxJson { get; set; }
        public string AttributeDescription { get; set; }
        public long AttributeCreatedAt { get; set; }
    }
}