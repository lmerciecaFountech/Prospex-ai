using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Enums
{
    public enum InteractionType
    {
        Assigned,
        Accepted,
        Declined,
        Referred,
        Skipped,
        AutoDeclined
    }
}