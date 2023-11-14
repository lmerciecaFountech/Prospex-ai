using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public abstract class Edge
    {
        public string Id { get; set; }
        public Prop<EdgeLabel> Label { get; set; }
        public Prop<long> CreatedAt { get; set; } = Prop<long>.Default(Today.Ticks);
        public Prop<long> UpdatedAt { get; set; } = Prop<long>.Default(Today.Ticks);
        public Prop<bool> IsValid { get; set; } = Prop<bool>.Default(true);
        public Prop<Source> Source { get; set; }

        protected Edge()
        {

        }

        protected Edge(EdgeLabel edgeLabel)
        {
            Label = edgeLabel;
        }

        protected Edge(EdgeLabel edgeLabel, Source source)
        {
            Label = edgeLabel;
            Source = source;
        }

        public virtual void SetId(string fromId, string toId)
        {
            //Preconditions.CheckNotNull(fromId, nameof(fromId));
            //Preconditions.CheckNotNull(toId, nameof(toId));

            Id = GuidHelper.Create(GuidHelper.DnsNamespace, $"{fromId}{toId}{Label}{Source}").ToString();
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
                                    {new KeyValuePair<string, string>(Entities.Source.Unset.Value, prop.ToString())}
                            };
                        }
                    }

                    return new
                    {
                        Key = name,
                        Value = new List<KeyValuePair<string, string>>
                            {new KeyValuePair<string, string>(Entities.Source.Unset.Value, value?.ToString())}
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
                            {new KeyValuePair<string, string>(Entities.Source.Unset.Value, value?.ToString())}
                    };
                })
                .Where(x => x.Value.Any());

            return fields.Concat(properties).ToDictionary(x => x.Key, x => x.Value);
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
                                    {new KeyValuePair<string, string>(Entities.Source.Unset.Value, prop.ToString())}
                            };
                        }
                    }

                    return new
                    {
                        Key = name,
                        Value = new List<KeyValuePair<string, string>>
                            {new KeyValuePair<string, string>(Entities.Source.Unset.Value, value?.ToString())}
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
                            {new KeyValuePair<string, string>(Entities.Source.Unset.Value, value?.ToString())}
                    };
                })
                .Where(x => x.Value.Any());

            return fields.Concat(properties).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}