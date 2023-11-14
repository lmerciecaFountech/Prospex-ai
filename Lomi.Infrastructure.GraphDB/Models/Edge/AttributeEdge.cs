using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class AttributeEdge : Edge
    {
        public AttributeEdge(EdgeLabel edgeLabel, string origin) : base(edgeLabel)
        {
            Origin = origin;
            LastRefreshedAt = DateTime.UtcNow.Ticks;
        }

        public AttributeEdge(EdgeLabel edgeLabel, Source source, string origin) : base(edgeLabel, source)
        {
            Origin = origin;
            LastRefreshedAt = DateTime.UtcNow.Ticks;
        }

        public override void SetId(string fromId, string toId)
        {
            //Preconditions.CheckNotNull(fromId, nameof(fromId));
            //Preconditions.CheckNotNull(toId, nameof(toId));
            //Preconditions.CheckNotNull(Source.Value, nameof(Source));
            //Preconditions.CheckNotNull(Origin.Value, nameof(Origin));

            //Id = GuidHelper.Create(GuidHelper.DnsNamespace, $"{fromId}{toId}{Label}{Source}{Origin}").ToString();
            Id = GuidHelper.Create(GuidHelper.DnsNamespace, $"{fromId}{toId}{Label.Value.Value}{Source.Value.Value}{Origin}").ToString();
        }

        public Prop<long> LastRefreshedAt { get; set; }

        public Prop<double?> Confidence { get; set; }
        public Prop<double?> Weight { get; set; }
        //public bool IsDirty { get; set; }
        public Prop<bool?> IsActive { get; set; }
        public Prop<string> Origin { get; set; }
        public Prop<int> Reinforcement { get; set; }
        public Prop<double> Multiplier { get; set; } = 1;
    }
}
