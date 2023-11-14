using Lomi.Infrastructure.GraphDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class WorkEdge : Edge
    {
        public WorkEdge(EdgeLabel edgeLabel, Source source) : base(edgeLabel, source)
        {
        }

        public Prop<string> Title { get; set; }
        public Prop<long> EmploymentFromDate { get; set; }
        public Prop<long> EmploymentToDate { get; set; }
        public Prop<bool> IsPrimary { get; set; }
    }
}