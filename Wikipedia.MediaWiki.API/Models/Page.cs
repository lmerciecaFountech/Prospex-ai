using System;

namespace Wikipedia.MediaWiki.Models
{
    /// <summary>
    /// Page information.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Page Id.
        /// </summary>
        public long PageId { get; set; }
        /// <summary>
        /// Page Id.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Page Id.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Page image url.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}