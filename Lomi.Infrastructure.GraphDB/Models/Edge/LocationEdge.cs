using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class LocationEdge : Edge
    {
        public Prop<int> Order { get; set; }
        public Prop<bool> IsSelected { get; set; }
    }
}
