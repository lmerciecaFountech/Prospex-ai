using Newtonsoft.Json;

namespace Wikipedia.MediaWiki.Models.Vendor
{
    /// <summary>
    /// Parsed information of page.
    /// </summary>
    internal class Text
    {
        /// <summary>
        /// Html content.
        /// </summary>
        [JsonProperty("*")]
        internal string Content { get; set; }
    }
}