using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class InteractionTypeExtensions
    {
        public static ReinforcementType? GetReinforcementType(this InteractionType reinforcementType)
        {
            switch (reinforcementType)
            {
                case InteractionType.Accepted:
                    return ReinforcementType.Accept;
                case InteractionType.AutoDeclined:
                    return ReinforcementType.AutoDecline;
                case InteractionType.Declined:
                    return ReinforcementType.Decline;
                case InteractionType.Referred:
                    return ReinforcementType.Refer;
                case InteractionType.Skipped:
                    return ReinforcementType.Skip;
            }
            return null;
        }
    }
}