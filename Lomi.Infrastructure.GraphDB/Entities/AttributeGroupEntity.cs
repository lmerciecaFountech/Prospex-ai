using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class AttributeGroupEntity : Entity
    {
        public Prop<VertexLabel> Label { get; set; }
        private Prop<string> _value;

        public AttributeGroupEntity(string value)
        {
            Value = value;
            Label = VertexLabel.AttributeGroup;
        }

        public Prop<string> Value
        {
            get => _value;
            set
            {
                _value = value;
                SetId(_value);
            }
        }
    }
}