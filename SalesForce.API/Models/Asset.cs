using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents an item of commercial value, such as a product sold by your company or a
    /// competitor, that a customer has purchased and installed.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_asset.htm
    /// </remarks>
    public class Asset : Base
    {
        /// <summary>
        /// ID of the Contact associated with this asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ContactId { get; set; }
        /// <summary>
        /// ID of the Account associated with this asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AccountId { get; set; }
        /// <summary>
        /// The asset’s parent asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ParentId { get; set; }
        /// <summary>
        /// The top-level asset in an asset hierarchy. Depending on where an asset 
        /// lies in the hierarchy, its root could be the same as its parent. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string RootAssetId { get; set; }
        /// <summary>
        /// ID of the Product2 associated with this asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Product2Id { get; set; }
        /// <summary>
        /// Indicates whether this Asset represents a product sold by a competitor
        /// (true) or not (false). 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string IsCompetitorProduct { get; set; }
        /// <summary>
        /// Name of the asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// Serial number for this asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string SerialNumber { get; set; }
        /// <summary>
        /// Date when the asset was installed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? InstallDate { get; set; }
        /// <summary>
        /// Date on which this asset was purchased.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? PurchaseDate { get; set; }
        /// <summary>
        /// Date when usage for this asset ends or expires.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? UsageEndDate { get; set; }
        /// <summary>
        /// Customizable picklist of values. The default picklist includes the 
        /// following values: Purchased, Shipped, Installed, Registered, Obsolete
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Status { get; set; }
        /// <summary>
        /// Price paid for this asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Price { get; set; }
        /// <summary>
        /// Quantity purchased or installed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Quantity { get; set; }
        /// <summary>
        /// Description of the asset.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        /// <summary>
        /// The asset’s owner. By default, the asset owner is the user who created 
        /// the asset record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OwnerId { get; set; }
        /// <summary>
        /// The date and time that the asset was last viewed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastViewedDate { get; set; }
        /// <summary>
        /// The date and time that the asset was last modified.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastReferencedDate { get; set; }
    }
}
