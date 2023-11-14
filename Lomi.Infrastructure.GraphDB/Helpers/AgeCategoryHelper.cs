using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Helpers
{
    public static class AgeCategoryHelper
    {
        public static AgeCategory From(DateTime? birthDate)
        {
            if (!birthDate.HasValue)
            {
                return AgeCategory.Unknown;
            }

            var today = DateTime.UtcNow.Date;

            // Calculate the age.
            var age = today.Year - birthDate.Value.Year;

            // Go back to the year the person was born in case of a leap year
            if (birthDate.Value > today.AddYears(-age))
                age--;

            if (age < 11)
            {
                return AgeCategory.OneToTen;
            }
            else if (age < 21)
            {
                return AgeCategory.ElevenToTwenty;
            }
            else if (age < 31)
            {
                return AgeCategory.TwentyOneToThirty;
            }
            else if (age < 41)
            {
                return AgeCategory.ThirtyOneToForty;
            }
            else if (age < 51)
            {
                return AgeCategory.FortyOneToFifty;
            }
            else if (age < 61)
            {
                return AgeCategory.FiftyOneToSixty;
            }
            else if (age < 71)
            {
                return AgeCategory.SixtyOneToSeventy;
            }
            else if (age < 81)
            {
                return AgeCategory.SeventyOneToEighty;
            }
            else if (age < 91)
            {
                return AgeCategory.EightyOneToNinety;
            }
            else
            {
                return AgeCategory.NinetyOneAndAbove;
            }
        }
    }
}
