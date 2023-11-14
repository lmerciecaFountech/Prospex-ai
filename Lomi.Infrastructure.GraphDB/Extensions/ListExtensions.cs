using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class ListExtensions
    {
        private static Random randomNumberGenerator = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;

                int k = randomNumberGenerator.Next(n + 1);

                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<T> Unwrap<T>(this IEnumerable<Maybe<T>> values) where T : class
        {
            return values.Where(x => x.HasValue).Select(e => e.Value).ToList();
        }

        public static List<string> ToValues<T>(this IEnumerable<T> collection, Func<T, string> func)
        {
            if (collection == null || collection.Count() == 0)
            {
                return new List<string>();
            }

            return new List<string>(collection.Select(func).Where(x => !string.IsNullOrEmpty(x)));
        }

        public static List<string> Concat(this List<string> list, string value)
        {
            if (list == null)
            {
                list = new List<string>();
            }

            if (!string.IsNullOrEmpty(value))
            {
                list.Add(value);
            }

            return list;
        }

        public static List<string> ToValues<T>(this IEnumerable<T> collection, Func<T, string> func, params string[] otherValues)
        {
            if (collection == null || collection.Count() == 0)
            {
                return new List<string>();
            }

            List<string> values = new List<string>(collection.Select(func));
            values.AddRange(otherValues);

            return values.Where(x => !string.IsNullOrEmpty(x)).ToList();
        }


        public static bool HasValue<T>(this IEnumerable<T> collection)
        {
            return collection != null && collection.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            collection.ToList().ForEach(action);
        }

        public static void AddIfNotExist(this List<string> values, string value)
        {
            if (!values.Contains(value))
            {
                values.Add(value);
            }
        }


        public static List<string> ToLower(this List<string> values)
        {
            if (values != null)
            {
                return values.Select(x => x.ToLower()).ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        public static List<T> Unwrap<T>(this List<Maybe<T>> list) where T : class
        {
            return list.Where(x => x.HasValue).Select(x => x.Value).ToList();
        }
    }

}
