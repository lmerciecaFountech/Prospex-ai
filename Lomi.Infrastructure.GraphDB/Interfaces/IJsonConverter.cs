using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Interfaces
{
    public interface IJsonConverter<T>
    {
        T Deserialize(string json);
        T Deserialize(JToken jToken);
    }
}