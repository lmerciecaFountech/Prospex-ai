using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents a contact, which is an individual associated with an account.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_contact.htm
    /// </remarks>
    public class Contact : Base
    {
        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains 
        /// the ID of the record that was kept. If this object was deleted for any 
        /// other reason, or has not been deleted, the value is null.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MasterRecordId { get; set; }
        /// <summary>
        /// ID of the Account associated with this contract.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AccountId { get; set; }
        /// <summary>
        /// Last name of the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LastName { get; set; }
        /// <summary>
        /// First name of the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string FirstName { get; set; }
        /// <summary>
        /// Honorific abbreviation, word, or phrase to be used in front of name in 
        /// greetings, such as Dr. or Mrs.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Salutation { get; set; }
        /// <summary>
        /// Concatenation of FirstName, MiddleName, LastName, and Suffix.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// The street name of the alternative address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OtherStreet { get; set; }
        /// <summary>
        /// The city name of the alternative address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OtherCity { get; set; }
        /// <summary>
        /// The state name of the alternative address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OtherState { get; set; }
        /// <summary>
        /// The postal code of the alternative address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OtherPostalCode { get; set; }
        /// <summary>
        /// The country name of the alternative address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OtherCountry { get; set; }
        /// <summary>
        /// Used with <see cref="OtherLongitude"/> to specify the precise geolocation of a 
        /// alternative address. Acceptable values are numbers between –90 and 90 with up to 
        /// 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public double? OtherLatitude { get; set; }
        /// <summary>
        /// Used with <see cref="OtherLatitude"/> to specify the precise geolocation of a 
        /// alternative address. Acceptable values are numbers between –180 and 180 with up to 
        /// 15 decimal places.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public double? OtherLongitude { get; set; }
        /// <summary>
        /// Accuracy level of the geocode for the alternative address.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string OtherGeocodeAccuracy { get; set; }
        /// <summary>
        /// The street name of the mailing address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MailingStreet { get; set; }
        /// <summary>
        /// The city name of the mailing address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MailingCity { get; set; }
        /// <summary>
        /// The state name of the mailing address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MailingState { get; set; }
        /// <summary>
        /// The postal code of the mailing address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MailingPostalCode { get; set; }
        /// <summary>
        /// The country name of the mailing address for this contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MailingCountry { get; set; }
        /// <summary>
        /// Used with <see cref="MailingLongitude"/> to specify the precise geolocation of a 
        /// mailing address. Acceptable values are numbers between –90 and 90 with up to 
        /// 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public double? MailingLatitude { get; set; }
        /// <summary>
        /// Used with <see cref="MailingLatitude"/> to specify the precise geolocation of a 
        /// mailing address. Acceptable values are numbers between –180 and 180 with up to 
        /// 15 decimal places.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public double? MailingLongitude { get; set; }
        /// <summary>
        /// Accuracy level of the geocode for the mailing address.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string MailingGeocodeAccuracy { get; set; }
        /// <summary>
        /// Telephone number for the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Phone { get; set; }
        /// <summary>
        /// Fax number for the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Fax { get; set; }
        /// <summary>
        /// Contact’s mobile phone number.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MobilePhone { get; set; }
        /// <summary>
        /// Home telephone number for the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string HomePhone { get; set; }
        /// <summary>
        /// Telephone for alternate address.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string OtherPhone { get; set; }
        /// <summary>
        /// The telephone number of the assistant.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AssistantPhone { get; set; }
        /// <summary>
        /// This field is not visible if IsPersonAccount is true.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ReportsToId { get; set; }
        /// <summary>
        /// Email address for the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Email { get; set; }
        /// <summary>
        /// Title of the contact such as CEO or Vice President.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Title { get; set; }
        /// <summary>
        /// The department of the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Department { get; set; }
        /// <summary>
        /// The name of the assistant.
        /// </summary>
        public string AssistantName { get; set; }
        /// <summary>
        /// The source of the lead.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LeadSource { get; set; }
        /// <summary>
        /// The birthdate of the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// A description of the contact.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        /// <summary>
        /// The ID of the owner of the account associated with this contact.
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
        /// Last CU Request Date.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastCURequestDate { get; set; }
        /// <summary>
        /// Last CU Update Date.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastCUUpdateDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this
        /// value is null, this record might only have been referenced
        /// <see cref="LastReferencedDate"/> and not viewed.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastViewedDate { get; set; }
        /// <summary>
        /// The timestamp for when the current user last viewed a record related to
        /// this record.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastReferencedDate { get; set; }
        /// <summary>
        /// If bounce management is activated and an email sent to the contact bounces,
        /// the reason the bounce occurred.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string EmailBouncedReason { get; set; }
        /// <summary>
        /// If bounce management is activated and an email sent to the contact bounces,
        /// the date and time the bounce occurred.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? EmailBouncedDate { get; set; }
        /// <summary>
        /// If bounce management is activated and an email is sent to a contact, 
        /// indicates whether the email bounced (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsEmailBounced { get; set; }
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
        /// References the ID of a company in Data.com. If an account has a value in this
        /// field, it means that the account was imported from Data.com. If the field 
        /// value is null, the account was not imported from Data.com.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Jigsaw { get; set; }
        /// <summary>
        /// Jigsaw Contact Id.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string JigsawContactId { get; set; }
        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com. Values are: Matched,
        /// Different, Acknowledged, NotFound, Inactive, Pending, SelectMatch, or Skipped.
        /// </summary>
        /// <remarks>
        /// Several values for CleanStatus display with different labels on the contact 
        /// record detail page.
        /// * Matched displays as In Sync
        /// * Acknowledged displays as Reviewed
        /// * Pending displays as Not Compared
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string CleanStatus { get; set; }
        /// <summary>
        /// Level (Custom field).
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Level { get; set; }
        /// <summary>
        /// Languages  (Custom field).
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Languages { get; set; }
    }
}
