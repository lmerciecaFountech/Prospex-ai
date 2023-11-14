using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.Extensions;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Occupations
    {
        public static Occupations None()
        {
            return new Occupations { Values = new List<string>() };
        }

        public static Occupations From(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return None();
            }
            return new Occupations { Values = new List<string> { value.ToLower() } };
        }

        public static Occupations From(IEnumerable<string> values)
        {

            return new Occupations { Values = values.ToList().ToLower() };
        }

        public List<string> Values { get; private set; }
    }
}
