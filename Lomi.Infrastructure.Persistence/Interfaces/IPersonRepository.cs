using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Interfaces
{
    public interface IPersonRepository
    {
        


        //Task AddCompanyAsync(Vertex personVertex, Vertex companyVertex, EdgeLabel label, Source source);
        //Task AddContactsAsync(string email, List<Person> people, Source source);
        //Task AddEmploymentsAsync(EmploymentHistory employmentHistory, Vertex person, Source source);
        //Task AddIdealClientsAsync(List<Person> idealClients, Source source, Vertex dnaVertex, Vertex personVertex);
        //Task AddLeadAsync(string personVertexId, string leadVertexId, double six, DateTime createdAt, DeliveryStatus deliveryStatus);
        //Task<Maybe<Vertex>> AddLocationAsync(Location location, Vertex vertex, Source source = null);
        //Task<List<Vertex>> AddPeopleAsync(List<Person> people, Source source);
        //Task<Vertex> AddPersonAsync(Person person, IEnumerable<Person> friends, Source source);
        //Task<Vertex> AddPersonAsync(Person person, Source source);
        //Task<Vertex> AddPersonAsync(string salesForceId, Person person, EdgeLabel edgeLabel, Source source);
        //Task AddPersonAsync(string salesForceId, Person person, Source source);
        //Task<Vertex> AddPersonAsync(VertexId id, Person person, EdgeLabel edgeLabel, Source source);
        //Task CopyAttributesFromPersonToDnaAsync(string prospexId);
        //Task CopyAttributesFromReinforcementToDnaAsync(string prospexId, ReinforcementType reinforcementType, string originId, params EdgeLabel[] edgeLabel);
        //Task<Vertex> CreateOrGetDnaAsync(Vertex personVertex);
        //Task CreateOrUpdateAverageReinforcementAsync(Vertex dnaVertex, Vertex attributeVertex, ReinforcementType reinforcementType, bool updateOnly);
        //Task<bool> DeactivateOnboardingAttributesAsync(string prospexId);
        //Task DeleteNonDeliveredLeadsAsync(string personVertexId);
        //Task FlagDnaAsync(string personVertexId);
        //Task<List<LeadDTO>> GetExistingLeadsAsync(string personVertexId);
        //Task<List<PersonFlaggedDnaDTO>> GetFlaggedDnasAsync();
        //Task<List<LeadQueueDTO>> GetMarkedForDeliveryLeadsAsync(string personVertexId);
        //Task<List<string>> GetLeadsAsync(string personVertexId, List<LeadFilter> leadFilters, string locationId = null, string ignoreLocationId = null, int? limit = null);
        //Task<IEnumerable<PersonDnaLeadsDTO>> GetMidnightPersonsAsync();
        //Task<List<LeadGeneratorDTO>> GetPeopleWithMarkedForDeliveryLeadsAsync();
        //Task<int> GetRequiredDailyLeadsAsync(string personVertexId);
        //Task<int> GetUtcOffsetAsync(string personVertexId);
        //Task InteractAsync(string userId, string leadId, InteractionType interactionType, string referralId = null);
        //Task<bool> IsLockedAsync(string prospexId);
        //Task SetRDLAsync(string personVertexId);
        //Task SetRelationshipAsync(Vertex person, Vertex person2, EdgeLabel edgeLabel, Source source);
        //Task UpdateAttributesFromReinforcementToDnaAsync(string prospexId, ReinforcementType reinforcementType, string originId = null, params EdgeLabel[] edgeLabel);
    }
}