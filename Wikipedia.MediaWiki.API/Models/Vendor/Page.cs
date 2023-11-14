using Newtonsoft.Json;

namespace Wikipedia.MediaWiki.Models.Vendor
{
    /// <summary>
    /// Page information.
    /// </summary>
    internal class Page
    {
        /// <summary>
        /// Page Id.
        /// </summary>
        [JsonProperty("pageid")]
        internal long PageId { get; set; }
        /// <summary>
        /// Page Id.
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }
        /// <summary>
        /// Page Id.
        /// </summary>
        [JsonProperty("extract")]
        internal string Description { get; set; }
        /// <summary>
        /// Page thumbnail.
        /// </summary>
        [JsonProperty("original")]
        internal Original Original { get; set; }
        /// <summary>
        /// Parsing information.
        /// </summary>
        [JsonProperty("text")]
        internal Text Parse { get; set; }
    }
}