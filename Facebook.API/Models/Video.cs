using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Video
    {
        public string Id { get; set; }
        public List<int> AdBreaks { get; set; }
        public DateTime BackdatedTime { get; set; }
        public string BackdatedTimeGranularity { get; set; }
        public string ContentCategory { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<string> CustomLabels { get; set; }
        public string Description { get; set; }
        public string EmbedHtml { get; set; }
        public bool Embeddable { get; set; }
        public Event Event { get; set; }
        public User From { get; set; }
        public string Icon { get; set; }
        public bool IsCrossPostVideo { get; set; }
        public bool IsCrossPostEligible { get; set; }
        public bool IsInstagramEligible { get; set; }
        public bool IsReferenceOnly { get; set; }
        public double Length { get; set; }
        public string LiveStatus { get; set; }
        public Place Place { get; set; }
        public bool Published { get; set; }
        public string Source { get; set; }
        public VideoStatus Status { get; set; }
        public string Title { get; set; }
        public string UniversalVideoId { get; set; }
        public DateTime UpdatedTime { get; set; }
    }

    internal class VideoStatus
    {
        public int ProcessingProgress { get; set; }
        public VideoStatusType Status { get; set; }
    }

    public enum VideoStatusType
    {
        READY,
        PROCESSING,
        ERROR
    }
}