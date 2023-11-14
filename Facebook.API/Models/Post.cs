using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Post
    {
        public string Id { get; set; }
        public DateTime BackdatedTime { get; set; }
        public bool CanReplyPrivately { get; set; }
        public string Caption { get; set; }
        public string CommentsMirroringDomain { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
        public int ExpandedHeight { get; set; }
        public int ExpandedWidth { get; set; }
        public User From { get; set; }
        public string FullPicture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Icon { get; set; }
        public bool IsAppShare { get; set; }
        public bool IsEligibleForPromotion { get; set; }
        public bool IsExpired { get; set; }
        public bool IsHidden { get; set; }
        public bool IsPopular { get; set; }
        public bool IsPublished { get; set; }
        public bool IsSpherical { get; set; }
        public string Link { get; set; }
        public string Message { get; set; }
        public Place Place { get; set; }
        public string TimelineVisibility { get; set; }
    }
}