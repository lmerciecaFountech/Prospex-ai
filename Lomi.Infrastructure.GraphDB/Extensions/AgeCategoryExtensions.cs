using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class AgeCategoryExtensions
    {
        public static string ToFriendlyString(this AgeCategory ageCategory)
        {
            switch (ageCategory)
            {
                case AgeCategory.OneToTen:
                    return "1-10";
                case AgeCategory.ElevenToTwenty:
                    return "11-20";
                case AgeCategory.TwentyOneToThirty:
                    return "21-30";
                case AgeCategory.ThirtyOneToForty:
                    return "31-40";
                case AgeCategory.FortyOneToFifty:
                    return "41-50";
                case AgeCategory.FiftyOneToSixty:
                    return "51-60";
                case AgeCategory.SixtyOneToSeventy:
                    return "61-70";
                case AgeCategory.SeventyOneToEighty:
                    return "71-80";
                case AgeCategory.EightyOneToNinety:
                    return "81-90";
                case AgeCategory.NinetyOneAndAbove:
                    return "91 and above";
                default:
                    return "Unknown";
            }
        }
    }
}