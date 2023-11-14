using Newtonsoft.Json;

namespace MicrosoftDynamics.API.Models
{
    public class BusinessUnit
    {
        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }

        [JsonProperty("businessunitid")]
        public string Businessunitid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}