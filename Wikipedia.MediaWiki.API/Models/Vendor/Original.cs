using Newtonsoft.Json;

namespace Wikipedia.MediaWiki.Models.Vendor
{
    /// <summary>
    /// Original image information.
    /// </summary>
    internal class Original
    {
        /// <summary>
        /// Thumbnail url.
        /// </summary>
        [JsonProperty("Source")]
        internal string Source { get; set; }
        /// <summary>
        /// Thumbnail width.
        /// </summary>
        [JsonProperty("width")]
        internal int Width { get; set; }
        /// <summary>
        /// Thumbnail height.
        /// </summary>
        [JsonProperty("height")]
        internal int Height { get; set; }
    }
}