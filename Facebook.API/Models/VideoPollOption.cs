using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class VideoPollOption
    {
        public string Id { get; set; }
        public bool IsCorrect { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public int TotalVotes { get; set; }
    }
}
