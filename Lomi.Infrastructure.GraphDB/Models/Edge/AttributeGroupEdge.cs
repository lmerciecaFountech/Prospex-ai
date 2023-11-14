using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class AttributeGroupEdge : Edge
    {
        public AttributeGroupEdge()
        {
            Label = EdgeLabel.Belongs;
        }
    }
}