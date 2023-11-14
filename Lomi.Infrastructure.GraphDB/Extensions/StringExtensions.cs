using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class StringExtensions
    {
        public static string EscapeSinqleQuotes(this string value)
        {
            return value.Trim()?.Replace("'", @"\'");
        }

        public static string EscapeData(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return Uri.EscapeDataString(value);
        }

        public static string UnEscapeData(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return Uri.UnescapeDataString(value);
        }

        public static string InQuotes(this string value)
        {
            return $"'{value}'";
        }

        public static string[] SafeSplit(this string value, params char[] separator)
        {
            return string.IsNullOrWhiteSpace(value)
                ? new string[] { }
                : value.Split(separator);
        }
    }
}