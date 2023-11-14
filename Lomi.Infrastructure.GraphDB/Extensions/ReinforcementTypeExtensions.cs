using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class ReinforcementTypeExtensions
    {

        public static int Value(this ReinforcementType reinforcementType)
        {
            switch (reinforcementType)
            {
                case ReinforcementType.Accept:
                //case ReinforcementType.Email:
                //case ReinforcementType.FacebookValid:
                //case ReinforcementType.LinkedInValid:
                //case ReinforcementType.SalesforceValid:
                //case ReinforcementType.DynamicsValid:
                //case ReinforcementType.Appointment:
                    return 2;
                case ReinforcementType.Refer:
                    return 1;
                case ReinforcementType.Skip:
                    return 0;
                case ReinforcementType.AutoDecline:
                    return -1;
                case ReinforcementType.Decline:
                //case ReinforcementType.FacebookInvalid:
                //case ReinforcementType.LinkedInInvalid:
                //case ReinforcementType.SalesforceInvalid:
                //case ReinforcementType.DynamicsInvalid:
                    return -2;
                default:
                    return 0;
            }
        }

        public static bool IsUpdateOnly(this ReinforcementType reinforcementType)
        {
            switch (reinforcementType)
            {
                case ReinforcementType.Accept:
                case ReinforcementType.Decline:
                case ReinforcementType.Refer:
                case ReinforcementType.Skip:
                case ReinforcementType.AutoDecline:
                //case ReinforcementType.SalesforceValid:
                //case ReinforcementType.SalesforceInvalid:
                //case ReinforcementType.DynamicsValid:
                //case ReinforcementType.DynamicsInvalid:
                    return false;
                //case ReinforcementType.Email:
                //case ReinforcementType.Appointment:
                //case ReinforcementType.FacebookValid:
                //case ReinforcementType.FacebookInvalid:
                //case ReinforcementType.LinkedInValid:
                //case ReinforcementType.LinkedInInvalid:
                default:
                    return true;
            }
        }

        public static InteractionType? InteractionType(this ReinforcementType reinforcementType)
        {
            switch (reinforcementType)
            {
                case ReinforcementType.Accept:
                    return Enums.InteractionType.Accepted;
                case ReinforcementType.AutoDecline:
                    return Enums.InteractionType.AutoDeclined;
                case ReinforcementType.Decline:
                    return Enums.InteractionType.Declined;
                case ReinforcementType.Refer:
                    return Enums.InteractionType.Referred;
                case ReinforcementType.Skip:
                    return Enums.InteractionType.Skipped;
            }
            return null;
        }

    }
}