using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class DateTimeExtensions
    {
        private static string format = "yyyy-MM-dd HH:mm:ss";


        public static DateTime ToDateTime(this string value)
        {
            DateTime dateTime;
            DateTime.TryParseExact(value, format, null, System.Globalization.DateTimeStyles.None, out dateTime);

            return dateTime;
        }

        public static string ToStringValue(this DateTime dateTime)
        {
            return dateTime.ToString(format);
        }

        public static string ToStringValue(this DateTime? dateTime)
        {
            return dateTime?.ToString(format) ?? string.Empty;
        }

        public static DateTime? FromTicks(this string value)
        {
            long ticks = 0;
            if (long.TryParse(value, out ticks))
            {
                return new DateTime(ticks);
            }
            else
            {
                return null;
            }
        }
    }
}