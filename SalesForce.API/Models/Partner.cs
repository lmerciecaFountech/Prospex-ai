using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents a partner relationship between two Account records or between an Opportunity and an Account.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_partner.htm
    /// </remarks>
    public class Partner : Base
    {
        /// <summary>
        /// ID of the Opportunity in a partner relationship between an Account and an Opportunity.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OpportunityId { get; set; }
        /// <summary>
        /// ID of the main Account in a partner relationship between two accounts.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AccountFromId { get; set; }
        /// <summary>
        /// ID of the Partner Account related to either an opportunity or an account.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AccountToId { get; set; }
        /// <summary>
        /// UserRole that the account has towards the related opportunity or account, such as consultant
        /// or distributor.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Role { get; set; }
        /// <summary>
        /// Indicates that the account is the primary partner for the opportunity. Only one account can
        /// be marked as primary for an opportunity. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsPrimary { get; set; }
        /// <summary>
        /// Reverse Partner Id.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ReversePartnerId { get; set; }
    }
}