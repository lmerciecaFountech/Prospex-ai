using SalesForce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForce.API
{
    public interface ISalesForceClient
    {
        Task<Account> GetAccount(string id);
        Task<List<Account>> GetAccounts();
        Task<Asset> GetAsset(string id);
        Task<List<Asset>> GetAssets();
        Task<Contact> GetContact(string id);
        Task<List<Contact>> GetContacts();
        Task<Event> GetEvent(string id);
        Task<List<Event>> GetEvents();
        Task<Lead> GetLead(string id);
        Task<List<Lead>> GetLeads();
        Task<List<Opportunity>> GetOpportunities();
        Task<Opportunity> GetOpportunity(string id);
        Task<List<Partner>> GetPartners();
        Task<Pricebook2> GetPricebook(string id);
        Task<List<Pricebook2>> GetPricebooks();
        Task<Product2> GetProduct(string id);
        Task<List<Product2>> GetProducts();
        Task<User> GetUser(string id);
        Task<List<User>> GetUsers();
    }
}
