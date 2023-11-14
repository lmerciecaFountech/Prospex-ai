using Newtonsoft.Json;

namespace MicrosoftDynamics.API.Models
{
    public class Organization
    {
        [JsonProperty("@odata.etag")]
        public string ODataEtag { get; set; }

        [JsonProperty("organizationid")]
        public string Organizationid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}