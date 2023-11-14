using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Album
    {
        public string Id { get; set; }
        public bool CanUpload { get; set; }
        public int Count { get; set; }
        public Photo CoverPhoto { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
        public User From { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        //public string Place { get; set; }
        public string Privacy { get; set; }
        public AlbumType Type { get; set; }
        public DateTime UpdatedTime { get; set; }
    }

    public enum AlbumType
    {
        APP,
        COVER,
        PROFILE,
        MOBILE,
        WALL,
        NORMAL,
        ALBUM
    }
}