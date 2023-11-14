using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// This object has several fields that are used only for quantity and revenue schedules (for example, annuities).
    /// </summary>
    /// <remarks>
    ///  Schedules are available only for orgs that have enabled the products and schedules features. If these features
    ///  aren’t enabled, the schedule fields don’t appear in the DescribeSObjectResult, and you can’t query, create, 
    ///  or update the fields.
    ///  https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_product2.htm
    /// </remarks>
    public class Product2 : Base
    {
        /// <summary>
        /// Default name of this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// Default product code for this record.
        /// </summary>
        /// <remarks>
        /// Your org defines the product code naming pattern.
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string ProductCode { get; set; }
        /// <summary>
        /// A text description of this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        /// <summary>
        /// Indicates whether this record is active (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsActive { get; set; }
        /// <summary>
        /// Name of the product family associated with this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Family { get; set; }
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
    }
}