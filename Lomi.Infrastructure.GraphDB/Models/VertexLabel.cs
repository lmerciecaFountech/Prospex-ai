using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class VertexLabel
    {
        private static Dictionary<string, VertexLabel> Values = new Dictionary<string, VertexLabel>();


        static VertexLabel()
        {
            Values[Label.Person.ToString()] = new VertexLabel(Label.Person.ToString());
            Values[Label.Company.ToString()] = new VertexLabel(Label.Company.ToString());
            Values[Label.Product.ToString()] = new VertexLabel(Label.Product.ToString());
            Values[Label.Location.ToString()] = new VertexLabel(Label.Location.ToString());
            Values[Label.Attribute.ToString()] = new VertexLabel(Label.Attribute.ToString());
            Values[Label.AttributeGroup.ToString()] = new VertexLabel(Label.AttributeGroup.ToString());
            Values[Label.DNA.ToString()] = new VertexLabel(Label.DNA.ToString());
        }

        public static VertexLabel Person => Values[Label.Person.ToString()];
        public static VertexLabel Company => Values[Label.Company.ToString()];
        public static VertexLabel Product => Values[Label.Product.ToString()];
        public static VertexLabel Location => Values[Label.Location.ToString()];
        public static VertexLabel Attribute => Values[Label.Attribute.ToString()];
        public static VertexLabel AttributeGroup => Values[Label.AttributeGroup.ToString()];
        public static VertexLabel DNA => Values[Label.DNA.ToString()];
        public string Value { get; set; }

        public static VertexLabel From(string value)
        {
            if (Values.ContainsKey(value))
            {
                return Values[value];
            }
            else
            {
                throw new ArgumentException($"Invalid value {value}");
            }
        }

        private VertexLabel(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}