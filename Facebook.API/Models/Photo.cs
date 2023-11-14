using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Photo
    {
        public int Id { get; set; }
        public Album Album { get; set; }
        public string AltText { get; set; }
        public string AltTextCustom { get; set; }
        public DateTime BackdatedTime { get; set; }
        public string BackdatedTimeGranularity { get; set; }
        public bool CanBackdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanTag { get; set; }
        public DateTime CreatedTime { get; set; }
        public Event Event { get; set; }
        public User From { get; set; }
        public int Height { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public Place Place { get; set; }
        //public string Profile { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int Width { get; set; }
    }
}