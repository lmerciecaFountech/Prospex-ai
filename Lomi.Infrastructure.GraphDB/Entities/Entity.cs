using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public abstract class Entity
    {
        
        private string _id;

        public string Id
        {
            get => _id;
            set
            {
                _id = PartitionId = value;
            }
        }

        public string PartitionId { get; set; }

        public Prop<long> CreatedAt { get; set; } = Prop<long>.Default(Today.Ticks);
        public Prop<long> UpdatedAt { get; set; } = Prop<long>.Default(Today.Ticks);

        public virtual string GetEntityType()
        {
            return GetType().Name;
        }

        public string SetId(string key, Source source = null, bool convertToGuid = true)
        {
            if (convertToGuid) return Id = GuidHelper.Create(GuidHelper.DnsNamespace, $"{GetType().Name}{source?.Value}{key}").ToString();
            return Id = key;
        }

        public static Guid SetId(string key, string className, Source source = null)
        {
            return GuidHelper.Create(GuidHelper.DnsNamespace, $"{className}{source?.Value}{key}");
        }

        public Dictionary<string, List<KeyValuePair<string, string>>> GetProperties()
        {
            var stringType = typeof(string);

            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => (x.PropertyType.IsPrimitive || x.PropertyType == stringType || x.PropertyType.IsGenericType &&
                            x.PropertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(Prop<>))) && x.CanWrite)
                .Select(x =>
                {
                    var name = x.Name == nameof(Id) ? x.Name.ToLower() : x.Name;
                    var value = x.GetValue(this, null);

                    //// ReSharper disable once InvertIf
                    if (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition()
                            .IsAssignableFrom(typeof(Prop<>)))
                    {
                        if (value is IProp prop)
                        {
                            return new
                            {
                                Key = name,
                                Value = new List<KeyValuePair<string, string>>
                                    {new KeyValuePair<string, string>(Source.Unset.Value, prop.ToString())}
                            };
                        }
                    }

                    return new
                    {
                        Key = name,
                        Value = new List<KeyValuePair<string, string>>
                            {new KeyValuePair<string, string>(Source.Unset.Value, value?.ToString())}
                    };
                })
                .Where(x => x.Value.Any());

            var fields = GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.FieldType.IsGenericType &&
                            x.FieldType.GetGenericTypeDefinition().IsAssignableFrom(typeof(DataSourceProp<>)))
                .Select(x =>
                {
                    var name = x.Name == nameof(Id) ? x.Name.ToLower() : x.Name;
                    var value = x.GetValue(this);

                    //// ReSharper disable once InvertIf
                    if (x.FieldType.IsGenericType && x.FieldType.GetGenericTypeDefinition()
                            .IsAssignableFrom(typeof(DataSourceProp<>)))
                    {
                        if (value is IDataSourceProp dataSourceProp)
                        {
                            return new
                            {
                                Key = name,
                                Value = dataSourceProp.GetProperties()
                            };
                        }
                    }

                    return new
                    {
                        Key = name,
                        Value = new List<KeyValuePair<string, string>>
                            {new KeyValuePair<string, string>(Source.Unset.Value, value?.ToString())}
                    };
                })
                .Where(x => x.Value.Any());

            return fields.Concat(properties).ToDictionary(x => x.Key, x => x.Value);
        }

        private Dictionary<string, string> GetProperties(object obj, PropertyInfo propertyInfo)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetValue(obj, null) != null)
                {
                    values[prop.Name] = prop.GetValue(obj, null).ToString();
                }
            }

            return values;
        }

        public Dictionary<string, List<KeyValuePair<string, string>>> GetMarkedAsDirty()
        {
            var stringType = typeof(string);

            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => (x.PropertyType.IsPrimitive || x.PropertyType == stringType || x.PropertyType.IsGenericType &&
                            x.PropertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(Prop<>))) && x.Name != nameof(Id) && x.CanWrite)
                .Select(x =>
                {
                    var name = x.Name;
                    var value = x.GetValue(this, null);

                    //// ReSharper disable once InvertIf
                    if (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition()
                            .IsAssignableFrom(typeof(Prop<>)))
                    {
                        if (value is IProp prop)
                        {
                            return new
                            {
                                Key = name,
                                Value = new List<KeyValuePair<string, string>>
                                    {new KeyValuePair<string, string>(Source.Unset.Value, prop.ToString())}
                            };
                        }
                    }

                    return new
                    {
                        Key = name,
                        Value = new List<KeyValuePair<string, string>>
                            {new KeyValuePair<string, string>(Source.Unset.Value, value?.ToString())}
                    };
                })
                .Where(x => x.Value.Any());

            var fields = GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.FieldType.IsGenericType &&
                            x.FieldType.GetGenericTypeDefinition().IsAssignableFrom(typeof(DataSourceProp<>)))
                .Select(x =>
                {
                    var name = x.Name == nameof(Id) ? x.Name.ToLower() : x.Name;
                    var value = x.GetValue(this);

                    //// ReSharper disable once InvertIf
                    if (x.FieldType.IsGenericType && x.FieldType.GetGenericTypeDefinition()
                            .IsAssignableFrom(typeof(DataSourceProp<>)))
                    {
                        if (value is IDataSourceProp dataSourceProp)
                        {
                            return new
                            {
                                Key = name,
                                Value = dataSourceProp.GetDirtyProperties()
                            };
                        }
                    }

                    return new
                    {
                        Key = name,
                        Value = new List<KeyValuePair<string, string>>
                            {new KeyValuePair<string, string>(Source.Unset.Value, value?.ToString())}
                    };
                })
                .Where(x => x.Value.Any());

            return fields.Concat(properties).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}