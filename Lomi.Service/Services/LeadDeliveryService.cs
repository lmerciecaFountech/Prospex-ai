using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.Persistence.Interfaces;
using Lomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class LeadDeliveryService : ILeadDeliveryService
    {
        #region Members

        private readonly IPersonRepository _personRepository;

        #endregion

        #region Constructor

        public LeadDeliveryService(IPersonRepository personRepository)
        {
            if (personRepository == null)
                throw new ArgumentNullException(nameof(personRepository));

            _personRepository = personRepository;
        }

        #endregion

        #region Methods

        public async Task<List<LeadQueueDTO>> GetMarkedForDeliveryLeadsAsync(string personVertexId, string personProspexId)
        {

            return null;
            //var leads = await _personRepository.GetMarkedForDeliveryLeadsAsync(personVertexId);

            //if (leads != null)
            //{
            //    for (int i = 0; i < leads.Count(); i++)
            //    {
            //        var lead = leads[i];
            //        lead.AccountId = personProspexId;
            //    }
            //}

            //return leads;
        }


        public async Task<List<LeadGeneratorDTO>> GetPersonsWithMarkedForDeliveryLeadsAsync()
        {
            return null;

            //var people = await _personRepository.GetPeopleWithMarkedForDeliveryLeadsAsync();
            //return people;
        }

        #endregion
    }
}