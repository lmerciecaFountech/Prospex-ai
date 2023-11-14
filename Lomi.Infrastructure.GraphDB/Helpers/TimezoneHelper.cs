using Lomi.Infrastructure.GraphDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Helpers
{
    public static class TimezoneHelper
    {
        public static int GetUtcOffset(PersonLocation location)
        {
            int utcOffset = 0;

            if (location?.Home.HasValue ?? false)
            {
                utcOffset = GetUtcOffset(location.Home.Value);
            }
            else if (location?.Work.HasValue ?? false)
            {
                utcOffset = GetUtcOffset(location.Work.Value);
            }
            else if (location.Other?.Any() ?? false)
            {
                utcOffset = GetUtcOffset(location.Other?.FirstOrDefault().Value);
            }

            return utcOffset;
        }

        public static int GetUtcOffset(Location location)
        {
            return location?.UtcOffset ?? 0;
        }
    }
}
