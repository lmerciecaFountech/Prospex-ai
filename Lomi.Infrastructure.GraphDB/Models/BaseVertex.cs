using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class BaseVertex : BaseGremlin
    {
        public Dictionary<string, List<Property>> Properties { get; set; }
        public P GetProperty<P>([CallerMemberName] string propertyName = null)
        {
            if (Properties != null &&
                Properties.TryGetValue(propertyName, out List<Property> value))
            {
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(P));
                    if (converter != null)
                    {
                        return (P)converter.ConvertFromString(value?.FirstOrDefault()?.Value);
                    }
                }
                catch (NotSupportedException)
                {
                    return default(P);
                }
            }

            return default(P);
        }
    }
}