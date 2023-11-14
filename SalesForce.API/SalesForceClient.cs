using AutoMapper;
using Salesforce.Force;
using SalesForce.Mappers;
using SalesForce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForce.API
{
    public class SalesForceClient : ISalesForceClient
    {
        private Configuration _configuration;
        private ForceClient _forceClient;

        private static List<Models.Vendor.DescribeSObjectResult> _sObjects = new List<Models.Vendor.DescribeSObjectResult>();

        static SalesForceClient()
        {
            SalesForceMapper.Initialize();
        }

        public SalesForceClient(Configuration configuration)
        {
            _configuration = configuration;
            _forceClient = new ForceClient(_configuration.InstanceUrl, _configuration.AccessToken, _configuration.ApiVersion);
        }

        public async Task<List<Account>> GetAccounts()
        {
            var data = await QueryAll<Models.Vendor.Account>();

            var accounts = Mapper.Map<List<Account>>(data);

            return accounts;
        }

        public async Task<List<Asset>> GetAssets()
        {
            var data = await QueryAll<Models.Vendor.Asset>();

            var assets = Mapper.Map<List<Asset>>(data);

            return assets;
        }

        public async Task<List<Contact>> GetContacts()
        {
            var data = await QueryAll<Models.Vendor.Contact>();

            var contacts = Mapper.Map<List<Contact>>(data);

            return contacts;
        }

        public async Task<List<Event>> GetEvents()
        {
            var data = await QueryAll<Models.Vendor.Event>();

            var events = Mapper.Map<List<Event>>(data);

            return events;
        }

        public async Task<List<Opportunity>> GetOpportunities()
        {
            var data = await QueryAll<Models.Vendor.Opportunity>();

            var opportunities = Mapper.Map<List<Opportunity>>(data);

            return opportunities;
        }

        public async Task<List<Lead>> GetLeads()
        {
            var data = await QueryAll<Models.Vendor.Lead>();

            var leads = Mapper.Map<List<Lead>>(data);

            return leads;
        }

        public async Task<List<Partner>> GetPartners()
        {
            var data = await QueryAll<Models.Vendor.Partner>();

            var partners = Mapper.Map<List<Partner>>(data);

            return partners;
        }

        public async Task<List<User>> GetUsers()
        {
            var data = await QueryAll<Models.Vendor.User>();

            var users = Mapper.Map<List<User>>(data);

            return users;
        }

        public async Task<List<Pricebook2>> GetPricebooks()
        {
            var data = await QueryAll<Models.Vendor.Pricebook2>();

            var pricebooks = Mapper.Map<List<Pricebook2>>(data);

            return pricebooks;
        }

        public async Task<List<Product2>> GetProducts()
        {
            var data = await QueryAll<Models.Vendor.Product2>();

            var products = Mapper.Map<List<Product2>>(data);

            return products;
        }

        public async Task<Account> GetAccount(string id)
        {
            var data = await GetById<Models.Vendor.Account>(id);

            var account = Mapper.Map<Account>(data);

            return account;
        }

        public async Task<Asset> GetAsset(string id)
        {
            var data = await GetById<Models.Vendor.Asset>(id);

            var asset = Mapper.Map<Asset>(data);

            return asset;
        }

        public async Task<Contact> GetContact(string id)
        {
            var data = await GetById<Models.Vendor.Contact>(id);

            var contact = Mapper.Map<Contact>(data);

            return contact;
        }

        public async Task<Event> GetEvent(string id)
        {
            var data = await GetById<Models.Vendor.Event>(id);

            var @event = Mapper.Map<Event>(data);

            return @event;
        }

        public async Task<Opportunity> GetOpportunity(string id)
        {
            var data = await GetById<Models.Vendor.Opportunity>(id);

            var opportunity = Mapper.Map<Opportunity>(data);

            return opportunity;
        }

        public async Task<Lead> GetLead(string id)
        {
            var data = await GetById<Models.Vendor.Lead>(id);

            var lead = Mapper.Map<Lead>(data);

            return lead;
        }

        public async Task<User> GetUser(string id)
        {
            var data = await GetById<Models.Vendor.User>(id);

            var user = Mapper.Map<User>(data);

            return user;
        }

        public async Task<Pricebook2> GetPricebook(string id)
        {
            var data = await GetById<Models.Vendor.Pricebook2>(id);

            var pricebook = Mapper.Map<Pricebook2>(data);

            return pricebook;
        }

        public async Task<Product2> GetProduct(string id)
        {
            var data = await GetById<Models.Vendor.Product2>(id);

            var product = Mapper.Map<Product2>(data);

            return product;
        }

        #region Helper Methods

        private async Task<List<T>> QueryAll<T>()
        {
            var name = typeof(T).Name;

            var fields = await GetFields(name);

            var data = await _forceClient.QueryAllAsync<T>($"SELECT {fields} FROM {name}");

            return data.Records;
        }

        private async Task<T> GetById<T>(string id)
        {
            var name = typeof(T).Name;

            var fields = await GetFields(name);

            var data = await _forceClient.QueryAllAsync<T>($"SELECT {fields} FROM {name} WHERE Id = '{id}'");

            return data.Records.FirstOrDefault();
        }

        private async Task<string> GetFields(string name)
        {
            var sObject = _sObjects.FirstOrDefault(x => x.name == name);

            if (sObject == null)
            {
                sObject = (await _forceClient.DescribeAsync<Models.Vendor.DescribeSObjectResult>(name));

                _sObjects.Add(sObject);
            }

            var fields = sObject.fields.Select(x => x.name);

            return string.Join(", ", fields);
        }

        #endregion
    }
}
