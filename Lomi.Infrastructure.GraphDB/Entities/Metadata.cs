using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Metadata
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        public void Add(string name, DateTime? dateValue)
        {
            //Add(name, dateValue.ToStringValue());
        }

        public void Add(string name, string value)
        {
            //Preconditions.CheckNotBlank(name, nameof(name));

            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            string existingValue;
            if (dict.TryGetValue(name, out existingValue))
            {
                dict[name] = string.Concat(existingValue, ",", value);
            }
            else
            {
                dict[name] = value;
            }
        }

        public void AddOrUpdate(string name, string value)
        {
            //Preconditions.CheckNotBlank(name, nameof(name));

            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            dict[name] = value;
        }

        public void Add(string name, List<string> values)
        {
            if (values == null || !values.Any())
            {
                return;
            }

            string value = string.Join(",", values);

            Add(name, value);
        }

        public Dictionary<string, string> GetValues()
        {
            return dict;
        }

        public bool TryGetValue(string propertyName, out string value)
        {
            return dict.TryGetValue(propertyName, out value);
        }
    }
}