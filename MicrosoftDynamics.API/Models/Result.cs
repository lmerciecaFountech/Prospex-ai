using Newtonsoft.Json;
using System.Collections.Generic;

namespace MicrosoftDynamics.API.Models
{
    public class Result<T>
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }

        [JsonProperty("value")]
        public List<T> Values { get; set; }
    }
}