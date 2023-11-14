using MicrosoftDynamics.API.Handlers;
using MicrosoftDynamics.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDynamics.API
{
    public class DynamicsClient : IDynamicsClient
    {
        private HttpClient _httpClient;
        private string _serviceUrl;

        public DynamicsClient(string serviceUrl, string version, string clientId, string clientSecret, string redirectUrl)
        {
            var dynamicsMessageHandler = new DynamicsMessageHandler(serviceUrl, clientId, clientSecret, redirectUrl);

            _serviceUrl = serviceUrl;

            _httpClient = new HttpClient(dynamicsMessageHandler);
            _httpClient.BaseAddress = new Uri($"{serviceUrl}api/data/{version}/");
            _httpClient.Timeout = TimeSpan.FromMinutes(1);
        }

        public DynamicsClient(string serviceUrl, string version, AuthenticationHeader authenticationHeader)
        {
            var dynamicsMessageHandler = new DynamicsMessageHandler(new AuthenticationHeader { Scheme = authenticationHeader.Scheme, Parameter = authenticationHeader.Parameter });

            _serviceUrl = serviceUrl;

            _httpClient = new HttpClient(dynamicsMessageHandler);
            _httpClient.BaseAddress = new Uri($"{serviceUrl}api/data/{version}/");
            _httpClient.Timeout = TimeSpan.FromMinutes(1);
        }

        public async Task<List<Account>> GetAccounts()
        {
            var properties = "accountcategorycode,accountid,accountnumber,address1_addressid,address1_addresstypecode,address1_city," +
                "address1_country,address1_county,address1_fax,address1_freighttermscode,address1_latitude,address1_line1," +
                "address1_line2,address1_line3,address1_longitude,address1_name,address1_postalcode,address1_postofficebox," +
                "address1_primarycontactname,address1_shippingmethodcode,address1_stateorprovince,address1_telephone1," +
                "address1_telephone2,address1_telephone3,address1_upszone,address1_utcoffset,address2_addressid," +
                "address2_addresstypecode,address2_city,address2_country,address2_county,address2_fax,address2_freighttermscode," +
                "address2_latitude,address2_line1,address2_line2,address2_line3,address2_longitude,address2_name," +
                "address2_postalcode,address2_postofficebox,address2_primarycontactname,address2_shippingmethodcode," +
                "address2_stateorprovince,address2_telephone1,address2_telephone2,address2_telephone3,address2_upszone," +
                "address2_utcoffset,businesstypecode,customertypecode,description,emailaddress1,emailaddress2,emailaddress3," +
                "industrycode,name,numberofemployees,primarytwitterid,stockexchange,telephone1,telephone2,telephone3," +
                "territorycode,territoryid,websiteurl,createdon,entityimage_url,versionnumber,address1_composite,address2_composite";

            var response = await _httpClient.GetAsync($"accounts?$select={properties}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var accountResult = JsonConvert.DeserializeObject<Result<Account>>(json);

                return accountResult.Values;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<BusinessUnit> GetBusinessUnit(string id)
        {
            var properties = "businessunitid,name";
            var filter = $"businessunitid eq {id}";

            var response = await _httpClient.GetAsync($"businessunits?$select={properties}&$filter={filter}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var businessUnitResult = JsonConvert.DeserializeObject<Result<BusinessUnit>>(json);

                return businessUnitResult.Values.FirstOrDefault();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<List<Contact>> GetContacts()
        {
            var properties = "address1_addressid,address1_addresstypecode,address1_city,address1_country,address1_county," +
                "address1_fax,address1_freighttermscode,address1_latitude,address1_line1,address1_line2,address1_line3," +
                "address1_longitude,address1_name,address1_postalcode,address1_postofficebox,address1_primarycontactname," +
                "address1_shippingmethodcode,address1_stateorprovince,address1_telephone1,address1_telephone2,address1_telephone3," +
                "address1_upszone,address1_utcoffset,address2_addressid,address2_addresstypecode,address2_city,address2_country," +
                "address2_county,address2_fax,address2_freighttermscode,address2_latitude,address2_line1,address2_line2,address2_line3," +
                "address2_longitude,address2_name,address2_postalcode,address2_postofficebox,address2_primarycontactname," +
                "address2_shippingmethodcode,address2_stateorprovince,address2_telephone1,address2_telephone2,address2_telephone3," +
                "address2_upszone,address2_utcoffset,address3_addressid,address3_addresstypecode,address3_city,address3_country," +
                "address3_county,address3_fax,address3_freighttermscode,address3_latitude,address3_line1,address3_line2," +
                "address3_line3,address3_longitude,address3_name,address3_postalcode,address3_postofficebox," +
                "address3_primarycontactname,address3_shippingmethodcode,address3_stateorprovince,address3_telephone1," +
                "address3_telephone2,address3_telephone3,address3_upszone,address3_utcoffset,anniversary,birthdate,business2," +
                "company,customersizecode,customertypecode,department,description,educationcode,emailaddress1,emailaddress2," +
                "emailaddress3,employeeid,firstname,gendercode,home2,jobtitle,lastname,managername,managerphone," +
                "marketingonly,middlename,mobilephone,suffix,telephone1,telephone2,telephone3,websiteurl,_accountid_value,createdon," +
                "entityimage_url,versionnumber,address1_composite,address2_composite,address3_composite";

            var response = await _httpClient.GetAsync($"contacts?$select={properties}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var contactResult = JsonConvert.DeserializeObject<Result<Contact>>(json);

                contactResult.Values.ForEach(contact => contact.EntityImageUrl = $"{_serviceUrl}{contact.EntityImageUrl}");

                return contactResult.Values;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<Organization> GetOrganization(string id)
        {
            var properties = "organizationid,name";
            var filter = $"organizationid eq {id}";

            var response = await _httpClient.GetAsync($"organizations?$select={properties}&$filter={filter}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var organizationResult = JsonConvert.DeserializeObject<Result<Organization>>(json);

                return organizationResult.Values.FirstOrDefault();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            var properties = "name,description,producttypecode,producturl,suppliername,validfromdate,validtodate,vendorid,vendorname,createdon,entityimage_url,versionnumber";

            var response = await _httpClient.GetAsync($"products?$select={properties}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<Result<Product>>(json);

                return productResult.Values;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<SystemUser> GetUser(string id)
        {
            var properties = "systemuserid,firstname,lastname,fullname";
            var filter = $"systemuserid eq {id}";

            var response = await _httpClient.GetAsync($"systemusers?$select={properties}&$filter={filter}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var systemUserResult = JsonConvert.DeserializeObject<Result<SystemUser>>(json);

                return systemUserResult.Values.FirstOrDefault();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<WhoAmI> WhoAmI()
        {
            var response = await _httpClient.GetAsync("WhoAmI");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var whoAmI = JsonConvert.DeserializeObject<WhoAmI>(json);

                return whoAmI;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}