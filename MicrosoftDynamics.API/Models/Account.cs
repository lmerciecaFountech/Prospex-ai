using MicrosoftDynamics.API.Enums;
using Newtonsoft.Json;
using System;

namespace MicrosoftDynamics.API.Models
{
    public class Account
    {
        [JsonProperty("@odata.etag")]
        public string ODataEtag { get; set; }

        [JsonProperty("accountcategorycode")]
        public AccountCategoryCode? AccountCategoryCode { get; set; }

        [JsonProperty("accountid")]
        public string AccountId { get; set; }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }

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

        [JsonProperty("businesstypecode")]
        public DefaultCode? BusinessTypeCode { get; set; }

        [JsonProperty("customertypecode")]
        public object CustomerTypeCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("emailaddress1")]
        public string EmailAddress1 { get; set; }

        [JsonProperty("emailaddress2")]
        public string EmailAddress2 { get; set; }

        [JsonProperty("emailaddress3")]
        public string EmailAddress3 { get; set; }

        [JsonProperty("industrycode")]
        public IndustryCode? IndustryCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("numberofemployees")]
        public long? NumberofEmployees { get; set; }

        [JsonProperty("primarytwitterid")]
        public string PrimaryTwitterId { get; set; }

        [JsonProperty("stockexchange")]
        public string StockExchange { get; set; }

        [JsonProperty("telephone1")]
        public string Telephone1 { get; set; }

        [JsonProperty("telephone2")]
        public string Telephone2 { get; set; }

        [JsonProperty("telephone3")]
        public string Telephone3 { get; set; }

        [JsonProperty("territorycode")]
        public DefaultCode? TerritoryCode { get; set; }

        [JsonProperty("websiteurl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("createdon")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("entityimage_url")]
        public string EntityImageUrl { get; set; }

        [JsonProperty("versionnumber")]
        public long VersionNumber { get; set; }

        [JsonProperty("address1_composite")]
        public string Address1Composite { get; set; }

        [JsonProperty("address2_composite")]
        public string Address2Composite { get; set; }
    }
}
