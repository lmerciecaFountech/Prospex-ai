using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Generator.Helpers
{
    public static class StringHelper
    {
        public static string JoinNotEmpty(string separator, IEnumerable<string> values)
        {
            var nonEmptyValues = values.Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join(separator, nonEmptyValues);
        }

        public static string GetFeature(string key, string[] values)
        {
            if (!string.IsNullOrWhiteSpace(key) && values?.Length > 0)
            {
                //var value = string.Join("|", values);

                //return GetFeature(key, value);

                return GetFeature(key, values.FirstOrDefault());
            }

            return null;
        }

        public static string GetFeature(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                return $"{key}={value}";
            }

            return null;
        }
    }
}