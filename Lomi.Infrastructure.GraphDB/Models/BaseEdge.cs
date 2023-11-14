using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class BaseEdge : BaseGremlin
    {
        public string InVLabel { get; set; }
        public string OutVLabel { get; set; }
        public string InV { get; set; }
        public string OutV { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public P GetProperty<P>([CallerMemberName] string propertyName = null)
        {
            if (Properties != null &&
                Properties.TryGetValue(propertyName, out string value))
            {
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(P));
                    if (converter != null)
                    {
                        return (P)converter.ConvertFromString(value);
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
