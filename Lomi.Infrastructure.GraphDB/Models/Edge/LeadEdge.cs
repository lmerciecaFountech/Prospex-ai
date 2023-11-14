using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class LeadEdge : Edge
    {
        public LeadEdge() : base(EdgeLabel.Lead, null)
        {

        }

        public Prop<DeliveryStatus> DeliveryStatus { get; set; }
        public Prop<double> Six { get; set; }
    }
}