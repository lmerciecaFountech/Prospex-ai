using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class InteractionDTO
    {
        public string UserId { get; set; }
        public string LeadId { get; set; }
        public string ReferralId { get; set; }
        public InteractionType InteractionType { get; set; }
    }
}