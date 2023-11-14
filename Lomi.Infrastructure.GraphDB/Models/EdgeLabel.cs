using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class EdgeLabel
    {
        private static Dictionary<string, EdgeLabel> Values = new Dictionary<string, EdgeLabel>();

        static EdgeLabel()
        {
            Values[Label.Employer.ToString()] = new EdgeLabel(Label.Employer.ToString());
            Values[Label.Location.ToString()] = new EdgeLabel(Label.Location.ToString());
            Values[Label.Knows.ToString()] = new EdgeLabel(Label.Knows.ToString());
            Values[Label.Friend.ToString()] = new EdgeLabel(Label.Friend.ToString());
            Values[Label.Competitor.ToString()] = new EdgeLabel(Label.Competitor.ToString());
            Values[Label.Sells.ToString()] = new EdgeLabel(Label.Sells.ToString());
            Values[Label.Bought.ToString()] = new EdgeLabel(Label.Bought.ToString());
            Values[Label.Customer.ToString()] = new EdgeLabel(Label.Customer.ToString());
            Values[Label.Partner.ToString()] = new EdgeLabel(Label.Partner.ToString());
            Values[Label.Is.ToString()] = new EdgeLabel(Label.Is.ToString());
            Values[Label.Has.ToString()] = new EdgeLabel(Label.Has.ToString());
            Values[Label.Mentions.ToString()] = new EdgeLabel(Label.Mentions.ToString());
            Values[Label.Buys.ToString()] = new EdgeLabel(Label.Buys.ToString());
            Values[Label.WorksIn.ToString()] = new EdgeLabel(Label.WorksIn.ToString());
            Values[Label.WorksAt.ToString()] = new EdgeLabel(Label.WorksAt.ToString());
            Values[Label.WorksWith.ToString()] = new EdgeLabel(Label.WorksWith.ToString());
            Values[Label.WorksFor.ToString()] = new EdgeLabel(Label.WorksFor.ToString());
            Values[Label.Vendor.ToString()] = new EdgeLabel(Label.Vendor.ToString());
            Values[Label.Other.ToString()] = new EdgeLabel(Label.Other.ToString());
            Values[Label.Belongs.ToString()] = new EdgeLabel(Label.Belongs.ToString());
            Values[Label.Average.ToString()] = new EdgeLabel(Label.Average.ToString());
            Values[Label.DNA.ToString()] = new EdgeLabel(Label.DNA.ToString());
            Values[Label.LivesIn.ToString()] = new EdgeLabel(Label.LivesIn.ToString());
            Values[Label.In.ToString()] = new EdgeLabel(Label.In.ToString());
            Values[Label.Ideal.ToString()] = new EdgeLabel(Label.Ideal.ToString());
            Values[Label.Emailed.ToString()] = new EdgeLabel(Label.Emailed.ToString());
            Values[Label.Refer.ToString()] = new EdgeLabel(Label.Refer.ToString());
            Values[Label.Accepted.ToString()] = new EdgeLabel(Label.Accepted.ToString());
            Values[Label.Declined.ToString()] = new EdgeLabel(Label.Declined.ToString());
            Values[Label.Referred.ToString()] = new EdgeLabel(Label.Referred.ToString());
            Values[Label.Skipped.ToString()] = new EdgeLabel(Label.Skipped.ToString());
            Values[Label.AutoDeclined.ToString()] = new EdgeLabel(Label.AutoDeclined.ToString());
            Values[Label.Founder.ToString()] = new EdgeLabel(Label.Founder.ToString());
            Values[Label.Lead.ToString()] = new EdgeLabel(Label.Lead.ToString());
        }

        public static EdgeLabel Employer => Values[Label.Employer.ToString()];
        public static EdgeLabel Location => Values[Label.Location.ToString()];
        public static EdgeLabel Friend => Values[Label.Friend.ToString()];
        public static EdgeLabel Knows => Values[Label.Knows.ToString()];
        public static EdgeLabel Competitor => Values[Label.Competitor.ToString()];
        public static EdgeLabel Sells => Values[Label.Sells.ToString()];
        public static EdgeLabel Bought => Values[Label.Bought.ToString()];
        public static EdgeLabel Partner => Values[Label.Partner.ToString()];
        public static EdgeLabel Customer => Values[Label.Customer.ToString()];
        public static EdgeLabel Is => Values[Label.Is.ToString()];
        public static EdgeLabel Has => Values[Label.Has.ToString()];
        public static EdgeLabel Mentions => Values[Label.Mentions.ToString()];
        public static EdgeLabel Buys => Values[Label.Buys.ToString()];
        public static EdgeLabel WorksIn => Values[Label.WorksIn.ToString()];
        public static EdgeLabel WorksAt => Values[Label.WorksAt.ToString()];
        public static EdgeLabel WorksWith => Values[Label.WorksWith.ToString()];
        public static EdgeLabel WorksFor => Values[Label.WorksFor.ToString()];
        public static EdgeLabel Vendor => Values[Label.Vendor.ToString()];
        public static EdgeLabel Other => Values[Label.Other.ToString()];
        public static EdgeLabel Belongs => Values[Label.Belongs.ToString()];
        public static EdgeLabel Average => Values[Label.Average.ToString()];
        public static EdgeLabel Dna => Values[Label.DNA.ToString()];
        public static EdgeLabel LivesIn => Values[Label.LivesIn.ToString()];
        public static EdgeLabel In => Values[Label.In.ToString()];
        public static EdgeLabel Ideal => Values[Label.Ideal.ToString()];
        public static EdgeLabel Emailed => Values[Label.Emailed.ToString()];
        public static EdgeLabel Refer => Values[Label.Refer.ToString()];
        public static EdgeLabel Accepted => Values[Label.Accepted.ToString()];
        public static EdgeLabel Declined => Values[Label.Declined.ToString()];
        public static EdgeLabel Referred => Values[Label.Referred.ToString()];
        public static EdgeLabel Skipped => Values[Label.Skipped.ToString()];
        public static EdgeLabel AutoDeclined => Values[Label.AutoDeclined.ToString()];
        public static EdgeLabel Founder => Values[Label.Founder.ToString()];
        public static EdgeLabel Lead => Values[Label.Lead.ToString()];

        public string Value { get; set; }

        public static EdgeLabel From(string value)
        {
            if (Values.ContainsKey(value))
            {
                return Values[value];
            }
            else
            {
                throw new ArgumentException($"Invalid value {value}");
            }
        }

        private EdgeLabel(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}