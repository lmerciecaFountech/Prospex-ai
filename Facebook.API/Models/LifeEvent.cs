using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class LifeEvent
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsHidden { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}