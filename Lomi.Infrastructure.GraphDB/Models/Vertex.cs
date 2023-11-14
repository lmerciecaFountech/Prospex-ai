using Lomi.Infrastructure.GraphDB.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class Vertex
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public Dictionary<string,List<Property>> Properties { get; set; }
        public DateTime? CreatedAt => GetProperty<string>().FromTicks();
        public DateTime? UpdatedAt => GetProperty<string>().FromTicks();
        public bool IsValid => GetProperty<bool>();
        public string Status { get; set; }

        public VertexId GetId()
        {
            return new VertexId(Id);
        }

        public VertexLabel GetLabel()
        {
            return VertexLabel.From(Label);
        }

        public T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (Properties != null &&
                Properties.TryGetValue(propertyName, out List<Property> value))
            {
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(value?.FirstOrDefault()?.Value);
                    }
                }
                catch (NotSupportedException)
                {
                    return default(T);
                }
            }

            return default(T);
        }
    }
}