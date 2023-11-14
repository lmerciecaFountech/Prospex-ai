using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Base fields that can be found on all objects.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Globally unique string that identifies a record.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true)
        /// or not (false).
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// ID of the User who created this record.
        /// </summary>
        public string CreatedById { get; set; }
        /// <summary>
        /// Date and time when this record was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The ID of the user who last modified this record.
        /// </summary>
        public string LastModifiedById { get; set; }
        /// <summary>
        /// Date and time when a user last modified this record.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
        /// <summary>
        /// Date and time when a user or automated process (such as a trigger)
        /// last modified this record.
        /// </summary>
        public DateTime? SystemModstamp { get; set; }
    }
}

