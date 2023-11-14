using Lomi.Infrastructure.GraphDB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Helpers
{
    public static class Today
    {
        public static long Ticks => DateTime.UtcNow.Ticks;
        public static DateTime Date => DateTime.UtcNow;
        public static string Value => DateTime.UtcNow.ToStringValue();
    }
}