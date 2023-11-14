using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Source
    {
        private static Dictionary<string, Source> Values = new Dictionary<string, Source>();

        static Source()
        {
            Values[SourceValue.Google] = new Source(SourceValue.Google, 5);
            Values[SourceValue.Facebook] = new Source(SourceValue.Facebook, 4);
            Values[SourceValue.LinkedIn] = new Source(SourceValue.LinkedIn, 8);
            Values[SourceValue.SalesForce] = new Source(SourceValue.SalesForce, 7);
            Values[SourceValue.Crunchbase] = new Source(SourceValue.Crunchbase, 3);
            Values[SourceValue.RecommendationEngine] = new Source(SourceValue.RecommendationEngine, 1);
            Values[SourceValue.Onboarding] = new Source(SourceValue.Onboarding, 9);
            Values[SourceValue.FullContact] = new Source(SourceValue.FullContact, 2);
            Values[SourceValue.Dynamics] = new Source(SourceValue.Dynamics, 6);
            Values[SourceValue.Unset] = new Source(SourceValue.Unset, 0);

        }

        public static Source Google => Values[SourceValue.Google];
        public static Source Facebook => Values[SourceValue.Facebook];
        public static Source LinkedIn => Values[SourceValue.LinkedIn];
        public static Source SalesForce => Values[SourceValue.SalesForce];
        public static Source Crunchbase => Values[SourceValue.Crunchbase];
        public static Source RecommendationEngine => Values[SourceValue.RecommendationEngine];
        public static Source Onboarding => Values[SourceValue.Onboarding];
        public static Source FullContact => Values[SourceValue.FullContact];
        public static Source Dynamics => Values[SourceValue.Dynamics];
        public static Source Unset => Values[SourceValue.Unset];

        public string Value { get; set; }
        public int Priority { get; set; }

        public static Source From(string value)
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

        public Source()
        {

        }

        private Source(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public static class SourceValue
    {
        public static string Google = "Google";
        public static string Facebook = "Facebook";
        public static string LinkedIn = "LinkedIn";
        public static string SalesForce = "SalesForce";
        public static string Crunchbase = "Crunchbase";
        public static string RecommendationEngine = "RecommendationEngine";
        public static string Onboarding = "Onboarding";
        public static string FullContact = "FullContact";
        public static string Dynamics = "Dynamics";
        public static string Unset = "Unset";
    }
}