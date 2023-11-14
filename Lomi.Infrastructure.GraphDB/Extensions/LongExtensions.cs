using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class LongExtensions
    {
        public static DateTime ToDateTime(this long value)
        {
            return new DateTime(value);
        }
    }
}