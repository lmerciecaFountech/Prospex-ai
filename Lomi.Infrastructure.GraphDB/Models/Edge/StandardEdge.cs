using Lomi.Infrastructure.GraphDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class StandardEdge : Edge
    {
        public StandardEdge(EdgeLabel edgeLabel) : base(edgeLabel)
        {
        }

        public StandardEdge(EdgeLabel edgeLabel, Source source) : base(edgeLabel, source)
        {
        }
    }
}
