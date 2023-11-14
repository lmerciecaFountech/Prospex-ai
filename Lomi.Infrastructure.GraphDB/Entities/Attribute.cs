using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Attribute
    {
        public Attribute(AttributeGroup group, IEnumerable<string> values)
        {
            Group = group;
            Values = values.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.ToLower()).ToList();
        }

        public Attribute(AttributeGroup group, string value)
        {
            Group = group;
            Values = new List<string> { value.ToLower() };
        }

        public AttributeGroup Group { get; set; }
        public List<string> Values { get; set; }
    }

    public class Attributes
    {
        public List<Attribute> Values { get; private set; }

        public Attributes()
        {
            Values = new List<Attribute>();
        }

        public void Add(AttributeGroup group, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Add(group, new List<string> { value });
            }
        }

        public void Add(AttributeGroup group, IEnumerable<string> values)
        {
            if (values != null && values.Where(x => !string.IsNullOrWhiteSpace(x)).Any())
            {
                Values.Add(new Attribute(group, values));
            }
        }

        public void AddUnstructured(IEnumerable<string> values)
        {
            Add(null, values);
        }

        public void AddUnstructured(string value)
        {
            Add(null, new List<string> { value });
        }
    }
}