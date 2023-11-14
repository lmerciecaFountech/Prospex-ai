using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class AttributeDTO
    {
        public string SourceVertexId { get; set; }
        public AttributeEdge Edge { get; set; }
        public AttributeEntity Attribute { get; set; }
        public AttributeGroupEntity Group { get; set; }
    }
}
