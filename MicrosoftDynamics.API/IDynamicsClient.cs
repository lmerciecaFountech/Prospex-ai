using MicrosoftDynamics.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDynamics.API
{
    public interface IDynamicsClient
    {
        Task<WhoAmI> WhoAmI();
        Task<SystemUser> GetUser(string id);
        Task<Organization> GetOrganization(string id);
        Task<BusinessUnit> GetBusinessUnit(string id);
        Task<List<Contact>> GetContacts();
        Task<List<Account>> GetAccounts();
        Task<List<Product>> GetProducts();
    }
}