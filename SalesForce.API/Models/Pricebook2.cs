using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents a price book that contains the list of products that your org sells.
    /// </summary>
    /// <remarks>https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_pricebook2.htm</remarks>
    public class Pricebook2 : Base
    {
        /// <summary>
        /// Name of this object.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is
        /// null, this record might only have been referenced <see cref="LastReferencedDate"/>
        /// and not viewed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastViewedDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LastReferencedDate { get; set; }
        /// <summary>
        /// Indicates whether the price book is active (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsActive { get; set; }
        /// <summary>
        /// Text description of the price book.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        /// <summary>
        /// Indicates whether the price book is the standard price book for the org (true) or not (false).
        /// </summary>
        /// <remarks>
        ///  Every org has one standard price book—all other price books are custom price books.
        /// </remarks>
        [BsonIgnoreIfDefault]
        public bool? IsStandard { get; set; }
    }
}