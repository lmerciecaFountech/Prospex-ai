using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Converters
{
    public class VertexPropertiesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);

            if (obj != null)
            {
                var properties = Activator.CreateInstance(objectType);
                var type = properties.GetType();

                foreach (var prop in obj.Properties())
                {
                    if (prop.Value is JArray)
                    {
                        var value = prop.Value.First;
                        var property = type.GetProperty(prop.Name);
                        if (property != null)
                        {
                            property.SetValue(properties, prop.Value.First.Last.ToObject(property.PropertyType));
                        }
                    }
                    else
                    {
                        var property = type.GetProperty(prop.Name);
                        if (property != null)
                        {
                            property.SetValue(properties, prop.Last.ToObject(property.PropertyType));
                        }
                    }
                }
                return properties;
            }
            return null;
        }
    }
}