using Lomi.Infrastructure.GraphDB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Skills
    {
        public static Skills None()
        {
            return new Skills { Values = new List<string>() };
        }

        public static Skills From(IEnumerable<string> values)
        {
            return values != null && values.Any() ? new Skills { Values = values.ToList().ToLower() } : None();
        }

        public static Skills From(string values)
        {
            // TODO: Logic
            return !string.IsNullOrEmpty(values) ? new Skills { Values = values.ToLower().Split(',').ToList() } : None();
        }

        public List<string> Values { get; private set; }
    }
}
