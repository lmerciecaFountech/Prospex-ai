using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents an individual account, which is an organization or person involved 
    /// with your business (such as customers, competitors, and partners).
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_account.htm
    /// </remarks>
    public class Account : Base
    {
        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains 
        /// the ID of the record that was kept. If this object was deleted for any 
        /// other reason, or has not been deleted, the value is null.
        /// </summary>
        public string MasterRecordId { get; set; }
        /// <summary>
        /// Name of the account. If the account has a record type of Person Account:
        /// This value is the concatenation of the FirstName, MiddleName, LastName, 
        /// and Suffix of the associated person contact.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Account number assigned to this account (not the unique, system-generated
        /// ID assigned during creation).
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// The ID of the user who currently owns this account. Default value is the
        /// user logged in to the API to perform the create.
        /// </summary>
        /// <remarks>
        /// If you have set up account teams in your organization, updating this field
        /// has different consequences depending on your version of the API:
        /// * For API version 12.0 and later, sharing records are kept, as they are 
        ///   for all objects.
        /// * For API version before 12.0, sharing records are deleted.
        /// * For API version 16.0 and later, users must have the “Transfer Record” 
        ///   permission in order to update (transfer) account ownership using 
        ///   this field.
        /// </remarks>
        public string OwnerId { get; set; }
        /// <summary>
        /// Name of the account’s location, for example Headquarters or London.
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        /// The source of the account record. For example, Advertisement, Data.com, 
        /// or Trade Show.
        /// </summary>
        public string AccountSource { get; set; }
        /// <summary>
        /// Estimated annual revenue of the account.
        /// </summary>
        public double? AnnualRevenue { get; set; }
        /// <summary>
        /// The street name of the billing address for this account.
        /// </summary>
        public string BillingStreet { get; set; }
        /// <summary>
        /// The city name of the billing address for this account.
        /// </summary>
        public string BillingCity { get; set; }
        /// <summary>
        /// The state name of the billing address for this account.
        /// </summary>
        public string BillingState { get; set; }
        /// <summary>
        /// The postal code of the billing address for this account.
        /// </summary>
        public string BillingPostalCode { get; set; }
        /// <summary>
        /// The country name of the billing address for this account
        /// </summary>
        public string BillingCountry { get; set; }
        /// <summary>
        /// Used with <see cref="BillingLongitude"/> to specify the precise geolocation of a
        /// billing address. Acceptable values are numbers between –90 and 90 with up to 
        /// 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        public double? BillingLatitude { get; set; }
        /// <summary>
        /// Used with <see cref="BillingLatitude"/> to specify the precise geolocation of a
        /// billing address. Acceptable values are numbers between –180 and 180 with up to 
        /// 15 decimal places.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        public double? BillingLongitude { get; set; }
        /// <summary>
        /// Accuracy level of the geocode for the billing address.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        public string BillingGeocodeAccuracy { get; set; }
        /// <summary>
        /// References the ID of a company in Data.com. If an account has a value in this 
        /// field, it means that the account was imported from Data.com. If the field value
        /// is null, the account was not imported from Data.com.
        /// </summary>
        /// <remarks>
        /// Available in API version 22.0 and later. 
        /// </remarks>
        public string Jigsaw { get; set; }
        /// <summary>
        /// Text description of the account. 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The Data Universal Numbering System (D-U-N-S) number is a unique, nine-digit number
        /// assigned to every business location in the Dun &amp;I ss Bradstreet database that has a 
        /// unique, separate, and distinct operation.
        /// </summary>
        /// <remarks>
        /// D-U-N-S numbers are used by industries and organizations around the world as a 
        /// global standard for business identification and tracking.
        /// </remarks>
        public string DunsNumber { get; set; }
        /// <summary>
        /// Number of employees working at the company represented by this account.
        /// </summary>
        public int? NumberOfEmployees { get; set; }
        /// <summary>
        /// Fax number for the account.
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// An industry associated with this account.
        /// </summary>
        public string Industry { get; set; }
        /// <summary>
        /// Jigsaw Company Id.
        /// </summary>
        public string JigsawCompanyId { get; set; }
        /// <summary>
        /// Value is one of the following, whichever is the most recent:
        /// * Due date of the most recent event logged against the record.
        /// * Due date of the most recently closed task associated with the record.
        /// </summary>
        public DateTime? LastActivityDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        public DateTime? LastReferencedDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is
        /// null, this record might only have been referenced <see cref="LastReferencedDate"/>
        /// and not viewed.
        /// </summary>
        public DateTime? LastViewedDate { get; set; }
        /// <summary>
        /// Ownership type for the account, for example Private, Public, or Subsidiary.
        /// </summary>
        public string Ownership { get; set; }
        /// <summary>
        /// ID of the parent object, if any.
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// Phone number for this account.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Blank if Social Accounts and Contacts isn't enabled for the organization or if 
        /// Social Accounts and Contacts is disabled for the requesting user. 
        /// </summary>
        /// <remarks>
        /// Generated URL returns an HTTP redirect (code 302) to the social network 
        /// profile image for the account.
        /// </remarks>
        public string PhotoUrl { get; set; }
        /// <summary>
        /// The account’s prospect rating, for example Hot, Warm, or Cold.
        /// </summary>
        public string Rating { get; set; }
        /// <summary>
        /// Standard Industrial Classification code of the company’s main business 
        /// categorization, for example, 57340 for Electronics.
        /// </summary>
        public string Sic { get; set; }
        /// <summary>
        /// A brief description of an organization’s line of business, based on its SIC code.
        /// </summary>
        public string SicDesc { get; set; }
        /// <summary>
        /// The street name of the shipping address for this account.
        /// </summary>
        public string ShippingStreet { get; set; }
        /// <summary>
        /// The city name of the shipping address for this account.
        /// </summary>
        public string ShippingCity { get; set; }
        /// <summary>
        /// The state name of the shipping address for this account.
        /// </summary>
        public string ShippingState { get; set; }
        /// <summary>
        /// The postal code of the shipping address for this account.
        /// </summary>
        public string ShippingPostalCode { get; set; }
        /// <summary>
        /// The country name of the shipping address for this account.
        /// </summary>
        public string ShippingCountry { get; set; }
        /// <summary>
        /// Used with <see cref="ShippingLongitude "/> to specify the precise geolocation
        /// of a shipping address. Acceptable values are numbers between –90 and 90 with up
        /// to 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        public double? ShippingLatitude { get; set; }
        /// <summary>
        /// Used with <see cref="ShippingLatitude"/> to specify the precise geolocation of 
        /// a shipping address. Acceptable values are numbers between –180 and 180 with up
        /// to 15 decimal places.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        public double? ShippingLongitude { get; set; }
        /// <summary>
        /// Accuracy level of the geocode for the shipping address.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        public string ShippingGeocodeAccuracy { get; set; }
        /// <summary>
        /// The stock market symbol for this account. 
        /// </summary>
        public string TickerSymbol { get; set; }
        /// <summary>
        /// Type of account, for example, Customer, Competitor, or Partner.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The website of this account.
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com. Values are: 
        /// Matched, Different, Acknowledged, NotFound, Inactive, Pending, SelectMatch,
        /// or Skipped.
        /// </summary>
        /// <remarks>
        /// Several values for CleanStatus display with different labels on the account 
        /// record detail page.
        /// * Matched displays as In Sync
        /// * Acknowledged displays as Reviewed
        /// * Pending displays as Not Compared
        /// </remarks>
        public string CleanStatus { get; set; }
        /// <summary>
        /// A name, different from its legal name, that an organization may use
        /// for conducting business. Similar to “Doing business as” or “DBA”. 
        /// </summary>
        public string Tradestyle { get; set; }
        /// <summary>
        /// The six-digit North American Industry Classification System (NAICS) code
        /// is the standard used by business and government to classify business
        /// establishments into industries, according to their economic activity 
        /// for the purpose of collecting, analyzing, and publishing statistical 
        /// data related to the U.S. business economy. Maximum size is 8 characters.
        /// </summary>
        public string NaicsCode { get; set; }
        /// <summary>
        /// A brief description of an organization’s line of business, based on 
        /// its NAICS code. 
        /// </summary>
        public string NaicsDesc { get; set; }
        /// <summary>
        /// The date when an organization was legally established.
        /// </summary>
        public string YearStarted { get; set; }
        /// <summary>
        /// Dandb Company Id.
        /// </summary>
        public string DandbCompanyId { get; set; }
        /// <summary>
        /// Customer Priority (Custom field).
        /// </summary>
        public string CustomerPriority { get; set; }
        /// <summary>
        /// SLA (Custom field).
        /// </summary>
        public string SLA { get; set; }
        /// <summary>
        /// Active (Custom field).
        /// </summary>
        public string Active { get; set; }
        /// <summary>
        /// Number of Locations (Custom field).
        /// </summary>
        public double? NumberofLocations { get; set; }
        /// <summary>
        /// Upsell Opportunity (Custom field).
        /// </summary>
        public string UpsellOpportunity { get; set; }
        /// <summary>
        /// SLA Serial Number (Custom field).
        /// </summary>
        public string SLASerialNumber { get; set; }
        /// <summary>
        /// SLA Expiration Date (Custom field).
        /// </summary>
        public DateTime? SLAExpirationDate { get; set; }

        public bool IsPersonAccount { get; set; }
    }
}

