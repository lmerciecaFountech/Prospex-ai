using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents a prospect or potential Opportunity.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_lead.htm
    /// </remarks>
    public class Lead : Base
    {
        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains the ID of the
        /// record that was kept. If this object was deleted for any other reason, or has not been
        /// deleted, the value is null.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MasterRecordId { get; set; }
        /// <summary>
        /// Last name of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LastName { get; set; }
        /// <summary>
        /// First name of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string FirstName { get; set; }
        /// <summary>
        /// Salutation for the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Salutation { get; set; }
        /// <summary>
        /// Concatenation of FirstName, MiddleName, LastName, and Suffix.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// Title for the lead, for example CFO or CEO.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Title { get; set; }
        /// <summary>
        /// Company of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Company { get; set; }
        /// <summary>
        /// Street number and name for the address of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Street { get; set; }
        /// <summary>
        /// City for the address of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string City { get; set; }
        /// <summary>
        /// State for the address of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string State { get; set; }
        /// <summary>
        /// Postal code for the address of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string PostalCode { get; set; }
        /// <summary>
        /// Country for the address of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Country { get; set; }
        /// <summary>
        /// Used with <see cref="Longitude"/> to specify the precise geolocation of an
        /// address. Acceptable values are numbers between –90 and 90 with up to 
        /// 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string Latitude { get; set; }
        /// <summary>
        /// Used with <see cref="Latitude"/> to specify the precise geolocation of an
        /// address. Acceptable values are numbers between –90 and 90 with up to 
        /// 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string Longitude { get; set; }
        /// <summary>
        /// Accuracy level of the geocode for the address on this object.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string GeocodeAccuracy { get; set; }
        /// <summary>
        /// Phone number for the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Phone { get; set; }
        /// <summary>
        /// Mobile phone number for the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MobilePhone { get; set; }
        /// <summary>
        /// Fax number for the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Fax { get; set; }
        /// <summary>
        /// Email address for the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Email { get; set; }
        /// <summary>
        /// Website for the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Website { get; set; }
        /// <summary>
        /// Blank if Social Accounts and Contacts isn't enabled for the organization or if 
        /// Social Accounts and Contacts is disabled for the requesting user. 
        /// </summary>
        /// <remarks>
        /// Generated URL returns an HTTP redirect (code 302) to the social network 
        /// profile image for the account.
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string PhotoUrl { get; set; }
        /// <summary>
        /// Description of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        /// <summary>
        /// Source from which the lead was obtained.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LeadSource { get; set; }
        /// <summary>
        /// Status code for this converted lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Status { get; set; }
        /// <summary>
        /// Industry the lead works in.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Industry { get; set; }
        /// <summary>
        /// Rating of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Rating { get; set; }
        /// <summary>
        /// Annual revenue for the company of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public double? AnnualRevenue { get; set; }
        /// <summary>
        /// Number of employees at the lead’s company.
        /// </summary>
        [BsonIgnoreIfDefault]
        public int? NumberOfEmployees { get; set; }
        /// <summary>
        /// ID of the owner of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OwnerId { get; set; }
        /// <summary>
        /// Indicates whether the Lead has been converted (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsConverted { get; set; }
        /// <summary>
        /// Date on which this Lead was converted.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? ConvertedDate { get; set; }
        /// <summary>
        /// Object reference ID that points to the Account into which the Lead has been converted.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ConvertedAccountId { get; set; }
        /// <summary>
        /// Object reference ID that points to the Contact into which the Lead has been converted.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ConvertedContactId { get; set; }
        /// <summary>
        /// Object reference ID that points to the Opportunity into which the Lead has been converted.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ConvertedOpportunityId { get; set; }
        /// <summary>
        /// If true, lead has been assigned, but not yet viewed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsUnreadByOwner { get; set; }
        /// <summary>
        /// Value is one of the following, whichever is the most recent:
        /// * Due date of the most recent event logged against the record.
        /// * Due date of the most recently closed task associated with the record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastActivityDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is null, this record might
        /// only have been referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastViewedDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastReferencedDate { get; set; }
        /// <summary>
        /// References the ID of a contact in Data.com. If a lead has a value in this field, it means that a contact was
        /// imported as a lead from Data.com. If the contact (converted to a lead) was not imported from Data.com, the
        /// field value is null. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Jigsaw { get; set; }
        /// <summary>
        /// Jigsaw Contact Id.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string JigsawContactId { get; set; }
        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com. Values are: Matched, Different, Acknowledged, 
        /// NotFound, Inactive, Pending, SelectMatch, or Skipped.
        /// Several values for CleanStatus display with different labels on the lead record detail page.
        /// * Matched displays as In Sync
        /// * Acknowledged displays as Reviewed
        /// * Pending displays as Not Compared
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CleanStatus { get; set; }
        /// <summary>
        /// The Data Universal Numbering System (D-U-N-S) number is a unique, nine-digit number assigned to every business
        /// location in the Dun &amp; Bradstreet database that has a unique, separate, and distinct operation. D-U-N-S numbers 
        /// are used by industries and organizations around the world as a global standard for business identification
        /// and tracking.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CompanyDunsNumber { get; set; }
        /// <summary>
        /// Dandb Company Id.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string DandbCompanyId { get; set; }
        /// <summary>
        /// If bounce management is activated and an email sent to the lead bounced, the reason the bounce occurred.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string EmailBouncedReason { get; set; }
        /// <summary>
        /// If bounce management is activated and an email sent to the lead bounced, the date and time the bounce occurred.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? EmailBouncedDate { get; set; }
        /// <summary>
        /// SIC Code (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string SICCode { get; set; }
        /// <summary>
        /// Product Interest (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ProductInterest { get; set; }
        /// <summary>
        /// Primary (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Primary { get; set; }
        /// <summary>
        /// Current Generators (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CurrentGenerators { get; set; }
        /// <summary>
        /// Number of Locations (Custom field)
        /// </summary>
        [BsonIgnoreIfDefault]
        public double? NumberofLocations { get; set; }
    }
}

