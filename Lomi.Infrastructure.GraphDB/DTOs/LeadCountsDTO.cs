using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class LeadCountsDTO
    {
        public int AcceptedCount { get; set; }
        public int NotAcceptedCount { get; set; }
        public int Diff { get { return AcceptedCount - NotAcceptedCount; } }
        public int Days { get; set; }
    }
}