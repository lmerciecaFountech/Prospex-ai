using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Event
    {
        public string Id { get; set; }
        public int AttendingCount { get; set; }
        public bool CanGuestsInvite { get; set; }
        public EventCategory Category { get; set; }
        public CoverPhoto Cover { get; set; }
        public int DeclinedCount { get; set; }
        public string Description { get; set; }
        public bool DiscountCodeEnabled { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool GuestListEnabled { get; set; }
        public int InterestedCount { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsDraft { get; set; }
        public bool IsPageOwned { get; set; }
        public int MaybeCount { get; set; }
        public string Name { get; set; }
        public int NoReplyCount { get; set; }
        public Place Place { get; set; }
        public string ScheduledPublishTime { get; set; }
        public EventType Type { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
