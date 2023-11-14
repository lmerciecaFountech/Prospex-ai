using MicrosoftDynamics.API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDynamics.API.Models
{
    public class Contact
    {
        [JsonProperty("@odata.etag")]
        public string ETag { get; set; }

        [JsonProperty("address1_addressid")]
        public string Address1AddressId { get; set; }

        [JsonProperty("address1_addresstypecode")]
        public Address1AddressTypeCode? Address1AddressTypeCode { get; set; }

        [JsonProperty("address1_city")]
        public string Address1City { get; set; }

        [JsonProperty("address1_country")]
        public string Address1Country { get; set; }

        [JsonProperty("address1_county")]
        public string Address1County { get; set; }

        [JsonProperty("address1_fax")]
        public string Address1Fax { get; set; }

        [JsonProperty("address1_freighttermscode")]
        public Address1FreightTermsCode? Address1FreightTermsCode { get; set; }

        [JsonProperty("address1_latitude")]
        public double? Address1Latitude { get; set; }

        [JsonProperty("address1_line1")]
        public string Address1Line1 { get; set; }

        [JsonProperty("address1_line2")]
        public string Address1Line2 { get; set; }

        [JsonProperty("address1_line3")]
        public string Address1Line3 { get; set; }

        [JsonProperty("address1_longitude")]
        public double? Address1Longitude { get; set; }

        [JsonProperty("address1_name")]
        public string Address1Name { get; set; }

        [JsonProperty("address1_postalcode")]
        public string Address1PostalCode { get; set; }

        [JsonProperty("address1_postofficebox")]
        public string Address1PostOfficeBox { get; set; }

        [JsonProperty("address1_primarycontactname")]
        public string Address1PrimaryContactName { get; set; }

        [JsonProperty("address1_shippingmethodcode")]
        public Address1ShippingMethodCode? Address1ShippingMethodCode { get; set; }

        [JsonProperty("address1_stateorprovince")]
        public string Address1StateOrProvince { get; set; }

        [JsonProperty("address1_telephone1")]
        public string Address1Telephone1 { get; set; }

        [JsonProperty("address1_telephone2")]
        public string Address1Telephone2 { get; set; }

        [JsonProperty("address1_telephone3")]
        public string Address1Telephone3 { get; set; }

        [JsonProperty("address1_upszone")]
        public string Address1UpsZone { get; set; }

        [JsonProperty("address1_utcoffset")]
        public int? Address1UtcOffset { get; set; }

        [JsonProperty("address2_addressid")]
        public string Address2AddressId { get; set; }

        [JsonProperty("address2_addresstypecode")]
        public DefaultCode? Address2AddressTypeCode { get; set; }

        [JsonProperty("address2_city")]
        public string Address2City { get; set; }

        [JsonProperty("address2_country")]
        public string Address2Country { get; set; }

        [JsonProperty("address2_county")]
        public string Address2County { get; set; }

        [JsonProperty("address2_fax")]
        public string Address2Fax { get; set; }

        [JsonProperty("address2_freighttermscode")]
        public DefaultCode? Address2FreightTermsCode { get; set; }

        [JsonProperty("address2_latitude")]
        public double? Address2Latitude { get; set; }

        [JsonProperty("address2_line1")]
        public string Address2Line1 { get; set; }

        [JsonProperty("address2_line2")]
        public string Address2Line2 { get; set; }

        [JsonProperty("address2_line3")]
        public string Address2Line3 { get; set; }

        [JsonProperty("address2_longitude")]
        public double? Address2Longitude { get; set; }

        [JsonProperty("address2_name")]
        public string Address2Name { get; set; }

        [JsonProperty("address2_postalcode")]
        public string Address2PostalCode { get; set; }

        [JsonProperty("address2_postofficebox")]
        public string Address2PostOfficeBox { get; set; }

        [JsonProperty("address2_primarycontactname")]
        public string Address2PrimaryContactName { get; set; }

        [JsonProperty("address2_shippingmethodcode")]
        public DefaultCode? Address2ShippingMethodCode { get; set; }

        [JsonProperty("address2_stateorprovince")]
        public string Address2StateOrProvince { get; set; }

        [JsonProperty("address2_telephone1")]
        public string Address2Telephone1 { get; set; }

        [JsonProperty("address2_telephone2")]
        public string Address2Telephone2 { get; set; }

        [JsonProperty("address2_telephone3")]
        public string Address2Telephone3 { get; set; }

        [JsonProperty("address2_upszone")]
        public string Address2UpsZone { get; set; }

        [JsonProperty("address2_utcoffset")]
        public int? Address2UtcOffset { get; set; }

        [JsonProperty("address3_addressid")]
        public string Address3AddressId { get; set; }

        [JsonProperty("address3_addresstypecode")]
        public DefaultCode? Address3AddressTypeCode { get; set; }

        [JsonProperty("address3_city")]
        public string Address3City { get; set; }

        [JsonProperty("address3_country")]
        public string Address3Country { get; set; }

        [JsonProperty("address3_county")]
        public string Address3County { get; set; }

        [JsonProperty("address3_fax")]
        public string Address3Fax { get; set; }

        [JsonProperty("address3_freighttermscode")]
        public DefaultCode? Address3FreightTermsCode { get; set; }

        [JsonProperty("address3_latitude")]
        public double? Address3Latitude { get; set; }

        [JsonProperty("address3_line1")]
        public string Address3Line1 { get; set; }

        [JsonProperty("address3_line2")]
        public string Address3Line2 { get; set; }

        [JsonProperty("address3_line3")]
        public string Address3Line3 { get; set; }

        [JsonProperty("address3_longitude")]
        public double? Address3Longitude { get; set; }

        [JsonProperty("address3_name")]
        public string Address3Name { get; set; }

        [JsonProperty("address3_postalcode")]
        public string Address3PostalCode { get; set; }

        [JsonProperty("address3_postofficebox")]
        public string Address3PostOfficeBox { get; set; }

        [JsonProperty("address3_primarycontactname")]
        public string Address3PrimaryContactName { get; set; }

        [JsonProperty("address3_shippingmethodcode")]
        public DefaultCode? Address3ShippingMethodCode { get; set; }

        [JsonProperty("address3_stateorprovince")]
        public string Address3StateOrProvince { get; set; }

        [JsonProperty("address3_telephone1")]
        public string Address3Telephone1 { get; set; }

        [JsonProperty("address3_telephone2")]
        public string Address3Telephone2 { get; set; }

        [JsonProperty("address3_telephone3")]
        public string Address3Telephone3 { get; set; }

        [JsonProperty("address3_upszone")]
        public string Address3UpsZone { get; set; }

        [JsonProperty("address3_utcoffset")]
        public int? Address3UtcOffset { get; set; }

        [JsonProperty("anniversary")]
        public DateTimeOffset? Anniversary { get; set; }

        [JsonProperty("birthdate")]
        public DateTimeOffset? Birthdate { get; set; }

        [JsonProperty("business2")]
        public string Business2 { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("customersizecode")]
        public DefaultCode? CustomerSizeCode { get; set; }

        [JsonProperty("customertypecode")]
        public DefaultCode? CustomerTypeCode { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("educationcode")]
        public DefaultCode? EducationCode { get; set; }

        [JsonProperty("emailaddress1")]
        public string EmailAddress1 { get; set; }

        [JsonProperty("emailaddress2")]
        public string EmailAddress2 { get; set; }

        [JsonProperty("emailaddress3")]
        public string EmailAddress3 { get; set; }

        [JsonProperty("employeeid")]
        public string EmployeeId { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("gendercode")]
        public GenderCode? GenderCode { get; set; }

        [JsonProperty("home2")]
        public string Home2 { get; set; }

        [JsonProperty("jobtitle")]
        public string JobTitle { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("managername")]
        public string ManagerName { get; set; }

        [JsonProperty("managerphone")]
        public string ManagerPhone { get; set; }

        [JsonProperty("marketingonly")]
        public bool MarketinOnly { get; set; }

        [JsonProperty("middlename")]
        public string MiddleName { get; set; }

        [JsonProperty("mobilephone")]
        public string MobilePhone { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("telephone1")]
        public string Telephone1 { get; set; }

        [JsonProperty("telephone2")]
        public string Telephone2 { get; set; }

        [JsonProperty("telephone3")]
        public string Telephone3 { get; set; }

        [JsonProperty("websiteurl")]
        public string Websiteurl { get; set; }

        [JsonProperty("_accountid_value")]
        public string AccountId { get; set; }

        [JsonProperty("createdon")]
        public DateTimeOffset Createdon { get; set; }

        [JsonProperty("entityimage_url")]
        public string EntityImageUrl { get; set; }

        [JsonProperty("versionnumber")]
        public long VersionNumber { get; set; }

        [JsonProperty("contactid")]
        public string ContactId { get; set; }

        [JsonProperty("address1_composite")]
        public string Address1Composite { get; set; }

        [JsonProperty("address2_composite")]
        public string Address2Composite { get; set; }

        [JsonProperty("address3_composite")]
        public string Address3Composite { get; set; }
    }
}
