using Lomi.Infrastructure.GraphDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public interface IDataSourceProp
    {
        List<KeyValuePair<string, string>> GetProperties();
        List<KeyValuePair<string, string>> GetDirtyProperties();
    }

    public struct DataSourceProp<T> : IDataSourceProp
    {
        public struct DataSourcePropItem<TY>
        {
            public Source Source;
            public Prop<TY> Value;
            public bool HasValue => Value?.HasValue ?? false;
            public bool IsDirty => Value?.IsDirty ?? false;

            public static implicit operator Prop<TY>(DataSourcePropItem<TY> value)
            {
                return value.Value;
            }

            public override string ToString()
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                return Value?.ToString();
            }
        }

        public static implicit operator Prop<T>(DataSourceProp<T> value)
        {
            return value.Item;
        }

        public static implicit operator string(DataSourceProp<T> value)
        {
            return value.ToString();
        }

        private List<DataSourcePropItem<T>> _items;
        private List<DataSourcePropItem<T>> Items => _items ?? (_items = new List<DataSourcePropItem<T>>());

        private DataSourcePropItem<T> Item => Items.FirstOrDefault();
        public T Value => Item.Value;
        public bool HasValue => Item.HasValue;
        public bool IsDirty => Item.IsDirty;

        public Prop<T> Get(Source source)
        {
            var item = Items.FirstOrDefault(x => x.Source == source);

            return item.Value;
        }

        public List<T> GetAll()
        {
            return Items.Where(x => x.HasValue).Select(x => x.Value.Value).ToList();
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void Set(Source source, T value, bool ignoreNull = false)
        {
            if (!Items.Any(x => x.Source?.Value == source?.Value && x.HasValue && x.Value.Value.Equals(value)))
            {
                if (!ignoreNull || (ignoreNull && value != null))
                {
                    Items.Add(new DataSourcePropItem<T> { Value = value, Source = source });
                }
            }
        }

        public void SetString(Source source, string value, bool withLowercase = false, bool ignoreNull = false)
        {
            var lowercase = value?.ToLowerInvariant();
            var originalValue = (T)Convert.ChangeType(value, typeof(T));
            var lowercaseValue = (T)Convert.ChangeType(lowercase, typeof(T));

            Set(source, originalValue, ignoreNull);

            if (withLowercase)
            {
                Set(source, lowercaseValue, ignoreNull);
            }
        }

        public List<KeyValuePair<string, string>> GetProperties()
        {
            return Items.Where(x => x.HasValue || x.IsDirty).Select(x => new KeyValuePair<string, string>(x.Source.Value, x.Value.ToString())).ToList();
        }

        public List<KeyValuePair<string, string>> GetDirtyProperties()
        {
            return Items.Where(x => x.IsDirty).Select(x => new KeyValuePair<string, string>(x.Source.Value, x.Value.ToString())).ToList();
        }

        public override string ToString()
        {
            return Item.ToString();
        }
    }
}
