using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing.Extensions
{
    public static class IEnumerableExtensions
    {
        public static List<T> Unwrap<T>(this IEnumerable<Maybe<T>> values) where T : class
        {
            return values.Where(x => x.HasValue).Select(e => e.Value).ToList();
        }
    }
}
