using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public interface IProp
    {
        bool IsDirty { get; set; }
    }

    public class Prop<T> : IProp
    {
        private T _value;

        public static implicit operator Prop<T>(T value)
        {
            return new Prop<T> { Value = value };
        }

        public static implicit operator T(Prop<T> value)
        {
            return value == null ? default(T) : value.Value;
        }

        public static Prop<T> Default(T value = default(T))
        {
            var prop = new Prop<T> { _value = value };

            return prop;
        }

        public bool IsDirty { get; set; }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                IsDirty = true;
            }
        }

        public bool HasValue => Value != null;

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}
