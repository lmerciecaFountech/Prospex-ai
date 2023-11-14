using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.API.Models
{
    internal class AccountSettings
    {
        public bool AlwaysUseHttps { get; set; }
        public bool DiscoverableByEmail { get; set; }
        public bool GeoEnabled { get; set; }
        public string Language { get; set; }
        public bool Protected { get; set; }
        public string ScreenName { get; set; }
        public bool ShowAllInlineMedia { get; set; }
        public SleepTime SleepTime { get; set; }
        public TimeZone TimeZone { get; set; }
        public TrendLocation TrendLocation { get; set; }
        public bool UseCookiePersonalization { get; set; }
        public string AllowContributorRequest { get; set; }
    }

    internal class SleepTime
    {
        public bool Enabled { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

    internal class TimeZone
    {
        public string Name { get; set; }
        public string TZInfoName { get; set; }
        public int UtcOffset { get; set; }
    }

    
}