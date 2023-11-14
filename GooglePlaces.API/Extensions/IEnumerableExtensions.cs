using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlaces.API.Extensions
{
    public static class IEnumerableExtensions
    {
        public static int GetOrderedHashCode<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return -1;
            return string.Join("", list.OrderBy(x => x)).GetHashCode();
        }
    }
}
