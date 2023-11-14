using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents an opportunity, which is a sale or pending deal.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_opportunity.htm
    /// </remarks>
    public class Opportunity : Base
    {
        /// <summary>
        /// ID of the account associated with this opportunity.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AccountId { get; set; }
        /// <summary>
        /// Indicates whether users other than the creator of the opportunity can (false)
        /// or can’t (true) see the opportunity details.
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsPrivate { get; set; }
        /// <summary>
        ///  A name for this opportunity.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// Text description of the opportunity.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        /// <summary>
        /// Current stage of this record. The StageName field controls several other fields on an opportunity.
        /// Each of the fields can be directly set or implied by changing the StageName field.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string StageName { get; set; }
        /// <summary>
        /// Estimated total sale amount. For opportunities with products, the amount is the sum of the related products.
        /// </summary>
        [BsonIgnoreIfDefault]
        public double? Amount { get; set; }
        /// <summary>
        /// Percentage of estimated confidence in closing the opportunity. It is implied, but not directly controlled, 
        /// by the StageName field.
        /// </summary>
        [BsonIgnoreIfDefault]
        public double? Probability { get; set; }
        /// <summary>
        /// Read-only field that is equal to the product of the opportunity Amount field and the Probability. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public double? ExpectedRevenue { get; set; }
        /// <summary>
        /// Number of items included in this opportunity. Used in quantity-based forecasting.
        /// </summary>
        [BsonIgnoreIfDefault]
        public double? TotalOpportunityQuantity { get; set; }
        /// <summary>
        /// Date when the opportunity is expected to close.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? CloseDate { get; set; }
        /// <summary>
        /// Type of opportunity. For example, Existing Business or New Business.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Type { get; set; }
        /// <summary>
        /// Description of next task in closing opportunity.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string NextStep { get; set; }
        /// <summary>
        /// Source of this opportunity, such as Advertisement or Trade Show.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LeadSource { get; set; }
        /// <summary>
        /// Directly controlled by StageName.
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsClosed { get; set; }
        /// <summary>
        /// Directly controlled by StageName.
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsWon { get; set; }
        /// <summary>
        /// The name of the forecast category. It is implied, but not directly controlled, by the StageName field.
        /// The values of this field are fixed enumerated values. The field labels are localized to the language
        /// of the user performing the operation, if localized versions of those labels are available for that
        /// language in the user interface.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ForecastCategory { get; set; }
        /// <summary>
        /// The name of the forecast category. It is implied, but not directly controlled, by the StageName field.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ForecastCategoryName { get; set; }
        /// <summary>
        /// ID of a related Campaign. This field is defined only for those organizations that have the campaign 
        /// feature Campaigns enabled.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CampaignId { get; set; }
        /// <summary>
        /// Read-only field that indicates whether the opportunity has associated line items. A value of true 
        /// means that Opportunity line items have been created for the opportunity. An opportunity can have
        /// opportunity line items only if the opportunity has a price book. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? HasOpportunityLineItem { get; set; }
        /// <summary>
        /// ID of a related Pricebook2 object. The Pricebook2Id field indicates which Pricebook2 applies to this 
        /// opportunity. The Pricebook2Id field is defined only for those organizations that have products
        /// enabled as a feature. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Pricebook2Id { get; set; }
        /// <summary>
        /// ID of the User who has been assigned to work this opportunity.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OwnerId { get; set; }
        /// <summary>
        /// Value is one of the following, whichever is the most recent:
        /// * Due date of the most recent event logged against the record.
        /// * Due date of the most recently closed task associated with the record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastActivityDate { get; set; }
        /// <summary>
        /// Represents the fiscal quarter. Valid values are 1, 2, 3, or 4.
        /// </summary>
        [BsonIgnoreIfDefault]
        public int? FiscalQuarter { get; set; }
        /// <summary>
        /// Represents the fiscal year, for example, 2006.
        /// </summary>
        [BsonIgnoreIfDefault]
        public int? FiscalYear { get; set; }
        /// <summary>
        /// If fiscal years are not enabled, the name of the fiscal quarter or period in which the opportunity
        /// <see cref="CloseDate"/> falls. Value should be in YYY Q format, for example, '2006 1' for first
        /// quarter of 2006.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Fiscal { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is null, this record
        /// might only have been referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastViewedDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastReferencedDate { get; set; }
        /// <summary>
        /// Indicates whether an opportunity has an open event or task (true) or not (false). 
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? HasOpenActivity { get; set; }
        /// <summary>
        /// Indicates whether an opportunity has an overdue task (true) or not (false). 
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? HasOverdueTask { get; set; }
        /// <summary>
        /// Delivery Installation Status (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string DeliveryInstallationStatus { get; set; }
        /// <summary>
        /// Tracking Number (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string TrackingNumber { get; set; }
        /// <summary>
        /// Order Number (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OrderNumber { get; set; }
        /// <summary>
        /// Current Generators (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CurrentGenerators { get; set; }
        /// <summary>
        /// Main Competitors (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MainCompetitors { get; set; }
    }
}