using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.API.Models
{
    internal class Tweet
    {
        public long Id { get; set; }
        public string IdStr { get; set; }
        public string CreatedAt { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        public bool Truncated { get; set; }
        public long InReplyToStatusId { get; set; }
        public string InReplyToStatusIdStr { get; set; }
        public long InReplyToUserId { get; set; }
        public long InReplyToUserStr { get; set; }
        public long InReplyToScreenName { get; set; }
        public User User { get; set; }
        public Coordinate[] Coordinates { get; set; }
        public Place Place { get; set; }
        public long QuotedStatusId { get; set; }
        public long QuotedStatusIdStr { get; set; }
        public bool IsQuoteStatus { get; set; }
        public Tweet QuotedStatus { get; set; }
        public Tweet RetweetedStatus { get; set; }
        public int QuoteCount { get; set; }
        public int ReplyCount { get; set; }
        public int RetweetCount { get; set; }
        public int FavoriteCount { get; set; }
        //public string Entities { get; set; }
        //public string ExtendedEntities { get; set; }
        public bool Favorited { get; set; }
        public bool Retweeted { get; set; }
        public bool PossiblySensitive { get; set; }
        public string FilterLevel { get; set; }
        public string Lang { get; set; }
        public MatchingRule[] MatchingRules { get; set; }
    }

    internal class MatchingRule
    {
        public string Tag { get; set; }
        public long Id { get; set; }
        public string IdStr { get; set; }
    }
}
