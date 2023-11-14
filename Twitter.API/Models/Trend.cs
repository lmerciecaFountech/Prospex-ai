using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.API.Models
{
    internal class Trend
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string PromotedContent { get; set; }
        public string Query { get; set; }
        public int TweetVolume { get; set; }
    }
}