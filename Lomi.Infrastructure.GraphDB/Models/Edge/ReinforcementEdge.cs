using Lomi.Infrastructure.GraphDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class ReinforcementEdge : Edge
    {
        public ReinforcementEdge(EdgeLabel edgeLabel, Source source, string origin) : base(edgeLabel, source)
        {
            Origin = origin;
        }

        public Prop<string> Origin { get; set; }
    }
}
