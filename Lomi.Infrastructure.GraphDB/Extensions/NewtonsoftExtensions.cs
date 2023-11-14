using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class NewtonsoftExtensions
    {
        public static void UnEscapeAllvalues(this JToken token)
        {
            foreach (var value in token.Values())
            {
                if (value.Type == JTokenType.String)
                {
                    var jvalue = value as JValue;
                    jvalue.Value = jvalue.Value?.ToString()?.UnEscapeData();
                }
            }
        }
    }
}