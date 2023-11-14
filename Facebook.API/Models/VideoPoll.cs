using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class VideoPoll
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public bool ShowResults { get; set; }
        public VideoPollStatus Status { get; set; }
    }

    public enum VideoPollStatus
    {
        CLOSED,
        VOTING_OPEN,
        RESULTS_OPEN
    }
}