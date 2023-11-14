using Lomi.Infrastructure.GraphDB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Interfaces
{
    public interface ILeadDeliveryService
    {
        Task<List<LeadQueueDTO>> GetMarkedForDeliveryLeadsAsync(string personVertexId, string personProspexId);
        Task<List<LeadGeneratorDTO>> GetPersonsWithMarkedForDeliveryLeadsAsync();
    }
}