using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.API.Models
{
    internal class List
    {
        public int Id { get; set; }
        public string IdStr { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public int SubscriberCount { get; set; }
        public int MemberCount { get; set; }
        public string Mode { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string FullName { get; set; }
        public string CreatedAt { get; set; }
        public bool Following { get; set; }
        public bool Protected { get; set; }
        public int FollowersCount { get; set; }
        public int FriendsCount { get; set; }
        public int ListedCount { get; set; }
        public int FavouritesCount { get; set; }
        public int UtcOffset { get; set; }
        public int TimeZone { get; set; }
        public bool GeoEnabled { get; set; }
        public bool Verified { get; set; }

    }
}