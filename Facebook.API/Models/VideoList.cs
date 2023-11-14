using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class VideoList
    {
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public int SeasonNumber { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public int VideosCount { get; set; }
    }
}