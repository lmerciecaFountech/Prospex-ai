using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SalesForce.Models
{
    /// <summary>
    /// Represents a user in your organization.
    /// </summary>
    /// <remarks>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_user.htm
    /// </remarks>
    public class User : Base
    {
        /// <summary>
        /// Contains the name that a user enters to log in to the API or the user interface.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Username { get; set; }
        /// <summary>
        /// The user’s last name.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LastName { get; set; }
        /// <summary>
        /// The user’s first name.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string FirstName { get; set; }
        /// <summary>
        /// Concatenation of FirstName and LastName.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        /// <summary>
        /// The name of the user’s company.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CompanyName { get; set; }
        /// <summary>
        /// The division associated with this user, similar to Department.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Division { get; set; }
        /// <summary>
        /// The company department associated with the user.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Department { get; set; }
        /// <summary>
        /// The user’s business title, such as “Vice President.”
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Title { get; set; }
        /// <summary>
        /// The street address associated with the User.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Street { get; set; }
        /// <summary>
        /// The city associated with the user.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string City { get; set; }
        /// <summary>
        /// The state associated with the User.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string State { get; set; }
        /// <summary>
        /// The user’s postal or ZIP code.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string PostalCode { get; set; }
        /// <summary>
        /// The country associated with the user.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Country { get; set; }
        /// <summary>
        /// Used with <see cref="Longitude"/> to specify the precise geolocation of an address.
        /// Acceptable values are numbers between –90 and 90 with up to 15 decimal places. 
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public double? Latitude { get; set; }
        /// <summary>
        /// Used with <see cref="Latitude"/> to specify the precise geolocation of an address.
        /// Acceptable values are numbers between –180 and 180 with up to 15 decimal places.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public double? Longitude { get; set; }
        /// <summary>
        /// Accuracy level of the geocode for the address.
        /// </summary>
        /// <remarks>
        /// See Compound Field Considerations and Limitations for details on geolocation
        /// compound fields.
        /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/compound_fields_limitations.htm#compound_fields_limitations
        /// </remarks>
        [BsonIgnoreIfDefault]
        public string GeocodeAccuracy { get; set; }
        /// <summary>
        /// The user’s email address.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Email { get; set; }
        /// <summary>
        /// The email address used as the From address when the user sends emails.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string SenderEmail { get; set; }
        /// <summary>
        /// The name used as the email sender when the user sends emails.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string SenderName { get; set; }
        /// <summary>
        /// The signature text added to emails.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Signature { get; set; }
        /// <summary>
        /// Stay In Touch Subject.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string StayInTouchSubject { get; set; }
        /// <summary>
        /// Stay In Touch Signature.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string StayInTouchSignature { get; set; }
        /// <summary>
        /// Stay In Touch Note.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string StayInTouchNote { get; set; }
        /// <summary>
        /// The user’s phone number.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Phone { get; set; }
        /// <summary>
        /// The user’s fax number.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Fax { get; set; }
        /// <summary>
        /// The user’s mobile or cellular phone number.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string MobilePhone { get; set; }
        /// <summary>
        /// The user’s alias. For example, jsmith.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Alias { get; set; }
        /// <summary>
        /// Name used to identify this user in the Community application, which includes the ideas and answers features.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CommunityNickname { get; set; }
        /// <summary>
        /// The text description of a user badge that appears over a user’s photo. Users of the same Chatter
        /// user type (internal, external) are badged.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string BadgeText { get; set; }
        /// <summary>
        /// Indicates whether the user has access to log in (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsActive { get; set; }
        /// <summary>
        /// Values for this field are named using region and key city, according to ISO standards.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string TimeZoneSidKey { get; set; }
        /// <summary>
        /// ID of the user’s UserRole.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string UserRoleId { get; set; }
        /// <summary>
        /// The field values are named according to the language, and country if necessary, using two-letter
        /// ISO codes. The set of names is based on the ISO standard. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LocaleSidKey { get; set; }
        /// <summary>
        /// Indicates whether the user receives informational email from Salesforce (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? ReceivesInfoEmails { get; set; }
        /// <summary>
        /// Indicates whether the user receives email for administrators from Salesforce (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? ReceivesAdminInfoEmails { get; set; }
        /// <summary>
        /// The email encoding for the user, such as ISO-8859-1 or UTF-8.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string EmailEncodingKey { get; set; }
        /// <summary>
        /// ID of the user’s Profile.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ProfileId { get; set; }
        /// <summary>
        /// The category of user license. Each UserType is associated with one or more UserLicense records.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string UserType { get; set; }
        /// <summary>
        /// The user’s language, such as “French” or “Chinese (Traditional).”
        /// </summary>
        [BsonIgnoreIfDefault]
        public string LanguageLocaleKey { get; set; }
        /// <summary>
        /// The user’s employee number.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// Id of the user who is a delegated approver for this user.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string DelegatedApproverId { get; set; }
        /// <summary>
        /// The Id of the user who manages this user.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ManagerId { get; set; }
        /// <summary>
        /// The date and time when the user last successfully logged in.
        /// </summary>
        /// <remarks>
        /// This value is updated if 60 seconds have elapsed since the user’s last login.
        /// </remarks>
        [BsonIgnoreIfDefault]
        public DateTime? LastLoginDate { get; set; }
        /// <summary>
        /// Last Password Change Date.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? LastPasswordChangeDate { get; set; }
        /// <summary>
        /// Offline Trial Expiration Date.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? OfflineTrialExpirationDate { get; set; }
        /// <summary>
        /// Offline Pda Trial Expiration Date.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTime? OfflinePdaTrialExpirationDate { get; set; }
        /// <summary>
        /// Indicates whether the user is enabled as a Forecast Manager (true) or not (false) in customizable 
        /// forecasting.
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? ForecastEnabled { get; set; }
        /// <summary>
        /// ID of the Contact associated with this account.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string ContactId { get; set; }
        /// <summary>
        /// ID of the Account associated with a Customer Portal user. This field is null for Salesforce users.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AccountId { get; set; }
        /// <summary>
        /// If Salesforce CRM Call Center is enabled, represents the call center to which this user is assigned.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string CallCenterId { get; set; }
        /// <summary>
        /// The user’s phone extension number.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string Extension { get; set; }
        /// <summary>
        /// Indicates the value that must be listed in the Subject element of a Security Assertion Markup Language
        /// (SAML) IDP certificate to authenticate the user for a client application using single sign-on.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string FederationIdentifier { get; set; }
        /// <summary>
        /// Information about the user, such as areas of interest or skills. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string AboutMe { get; set; }
        /// <summary>
        /// The URL for the user's profile photo.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string FullPhotoUrl { get; set; }
        /// <summary>
        /// The URL for a thumbnail of the user's profile photo. 
        /// </summary>
        [BsonIgnoreIfDefault]
        public string SmallPhotoUrl { get; set; }
        /// <summary>
        /// Required. The frequency at which the system sends the user’s Chatter personal email digest. The valid values are:
        /// D = Daily
        /// W = Weekly
        /// N = Never
        /// </summary>
        [BsonIgnoreIfDefault]
        public string DigestFrequency { get; set; }
        /// <summary>
        /// The default frequency for sending the user's Chatter group email notifications when the user joins groups. 
        /// The valid values are:
        /// P—Email on every post
        /// D—Daily digests
        /// W—Weekly digests
        /// N—Never
        /// </summary>
        [BsonIgnoreIfDefault]
        public string DefaultGroupNotificationFrequency { get; set; }
        /// <summary>
        /// The Data.com user’s monthly addition limit.
        /// </summary>
        [BsonIgnoreIfDefault]
        public int? JigsawImportLimitOverride { get; set; }
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
        /// The URL for the user's banner photo.
        /// </summary>
        [BsonIgnoreIfDefault]
        public string BannerPhotoUrl { get; set; }
        /// <summary>
        /// Indicates whether a user has a profile photo (true) or not (false).
        /// </summary>
        [BsonIgnoreIfDefault]
        public bool? IsProfilePhotoActive { get; set; }
    }
}