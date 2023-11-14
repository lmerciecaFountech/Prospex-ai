using Newtonsoft.Json;

namespace Wikipedia.MediaWiki.Models.Vendor
{
    /// <summary>
    /// Parsing result information.
    /// </summary>
    internal class Parse
    {
        /// <summary>
        /// Parsed page with html content.
        /// </summary>
        [JsonProperty("parse")]
        internal Page Page { get; set; }
        /// <summary>
        /// Parsing error information.
        /// </summary>
        [JsonProperty("error")]
        internal Error Error { get; set; }
    }
}
