using Newtonsoft.Json;

namespace Wikipedia.MediaWiki.Models.Vendor
{
    /// <summary>
    /// Erorr result.
    /// </summary>
    internal class Error
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty("code")]
        internal string Code { get; set; }
        /// <summary>
        /// Error information.
        /// </summary>
        [JsonProperty("info")]
        internal string Info { get; set; }
        /// <summary>
        /// More informationation about error.
        /// </summary>
        [JsonProperty("*")]
        internal string MoreInfo { get; set; }
    }
}
