using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.Persistence.Interfaces;
using Lomi.Infrastructure.Persistence.Repositories;
using Lomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class LeadGeneratorService : ILeadGeneratorService
    {
        #region Members

        private readonly PersonRepository _personRepository;
        private readonly LocationRepository _locationRepository;
        private readonly AttributeRepository _attributeRepository;
        private const int RATE_OF_CHANG_MARGIN = 1;
        private const double ACO_GRAVITY = 0.01;
        private const double ACO_THRESHOLD = 0.3;
        private const int MAX_RDL_TIMES_5 = 1;
        private const int FilteredUsersLimit = 20;
        //private string _personVertexId;
        //private string _personProspexId;

        #endregion

        #region Constructor

        public LeadGeneratorService()
        {
            _personRepository = new PersonRepository();
            _locationRepository = new LocationRepository();
            _attributeRepository = new AttributeRepository();
            //_personVertexId = personVertexId;
            //_personProspexId = personProspexId;
        }

        #endregion

        #region Methods

        public async Task<Tuple<string,List<string>>> GenerateAsync(string personVertexId, string personProspexId)
        {
            var requiredDailyLeads = await _personRepository.GetRequiredDailyLeadsAsync(personVertexId);

            if (requiredDailyLeads == 0)
                return null;

            //var existingLeads = await _personRepository.GetExistingLeadsAsync(personVertexId);
            //var requiredLeads = RateOfChange(existingLeads.Select(x => new { UpdatedOn = new DateTime(x.UpdatedAt), Accepted = x.Accepted })
            //    .Where(l => l.UpdatedOn.AddDays(5) > DateTime.Today.AddDays(1))
            //    .GroupBy(l => l.UpdatedOn.Date)
            //    .OrderBy(l => l.Key)
            //    .Select((l, i) => new LeadCountsDTO()
            //    {
            //        AcceptedCount = l.Where(x => x.Accepted).Count(),
            //        NotAcceptedCount = l.Count() - l.Where(x => x.Accepted).Count(),
            //        Days = i,
            //    }));

            //if (requiredLeads + RATE_OF_CHANG_MARGIN > 0.01)
            //{
            //await _personRepository.DeleteNonDeliveredLeadsAsync(personVertexId);

            var location = await _locationRepository.GetCityCountryAsync(personVertexId);
            IEnumerable<string> filteredUsers = new List<string>();

            if (location == null)
            {
                filteredUsers = await GetUsersWithoutFilterAsync(personVertexId);
            }
            else
            {
                var countryId = location.CountryId;
                var cityId = location.CityId;

                filteredUsers = await GetUsersAsync(personVertexId, countryId, cityId);

                if (filteredUsers.Count() < MAX_RDL_TIMES_5)
                {
                    //await _personRepository.FlagDnaAsync(personVertexId);

                    filteredUsers = await GetUsersExcludeUnindexedAsync(personVertexId, countryId, cityId);

                    if (filteredUsers.Count() < MAX_RDL_TIMES_5)
                    {
                        filteredUsers = await GetUsersCountryCityOnlyAsync(personVertexId, countryId, cityId);

                        if (filteredUsers.Count() < MAX_RDL_TIMES_5)
                        {
                            filteredUsers = await GetUsersCountryOnlyAsync(personVertexId, countryId);

                            if (filteredUsers.Count() < MAX_RDL_TIMES_5)
                            {
                                filteredUsers = await GetUsersWithoutFilterAsync(personVertexId);
                            }
                        }
                    }
                }
            }

            var sixes = new Dictionary<string, double>();
            var sixAttributes = await _attributeRepository.GetSixAttributesAsync(personVertexId);
            Tuple<string, List<string>> leads = new Tuple<string, List<string>>(personProspexId, new List<string>());
            foreach (var user in filteredUsers)
            {
                var attributeIds = await _attributeRepository.GetAttributesIdAsync(user);


                //var six = sixAttributes.Join(attributeIds, sa => sa.AttributeVertexId, a => a, (sa, a) => sa);
                var six = sixAttributes.Join(attributeIds, sa => sa.AttributeVertexId, a => a, (sa, a) => sa)
                .Where(sa => (sa.Confidence - (DateTime.UtcNow - new DateTime(sa.LastRefreshedAt)).TotalDays * ACO_GRAVITY) > ACO_THRESHOLD);

                double average = 0;

                if (six.Any())
                {
                    average = six.Average(sa => sa.Weight);
                }
                sixes.Add(user, average);
            }

            var orderedLeads = sixes.OrderByDescending(x => x.Value);
            var markForDeliveryLeads = orderedLeads.Take(requiredDailyLeads);
            var undeliveredLeads = orderedLeads.Skip(requiredDailyLeads);

            var now = DateTime.UtcNow;
            var rand = new Random();
            var i = 0;

            var utc = await _personRepository.GetUtcOffsetAsync(personVertexId);

            foreach (var lead in markForDeliveryLeads)
            {
                var lomiId = await _personRepository.GetLomiIdAsync(lead.Key);
                leads.Item2.Add(lomiId);
                var createdAt = new DateTime(now.Year, now.Month, now.Day, 6, rand.Next(0, 31), 0, DateTimeKind.Utc).AddHours(i++).AddMinutes(utc);
                await _personRepository.AddLeadAsync(personVertexId, lead.Key, lead.Value, createdAt, DeliveryStatus.MarkForDelivery);
            }
            return leads;
            //foreach (var lead in undeliveredLeads)
            //{
            //    var createdAt = new DateTime(now.Year, now.Month, now.Day, 6, rand.Next(0, 31), 0, DateTimeKind.Utc).AddHours(i++).AddMinutes(utc);
            //    await _personRepository.AddLeadAsync(personVertexId, lead.Key, lead.Value, createdAt, DeliveryStatus.Undelivered);
            //}
            ////}
        }

        #endregion

        #region Helper Methods

        private async Task<IEnumerable<string>> GetUsersAsync(string personVertexId, string countryId, string cityId)
        {
            var leadsFromSameCity = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
                {
                    LeadFilter.City,
                    LeadFilter.AttributeGroup,
                    LeadFilter.Unindexed
                }, cityId);

            var sameCountryCount = (int)Math.Round((double)leadsFromSameCity.Count / 5);

            var leadsFromSameCountry = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
                {
                    LeadFilter.Country20,
                    LeadFilter.AttributeGroup,
                    LeadFilter.Unindexed
                }, countryId, cityId, sameCountryCount);

            var filteredUsers = leadsFromSameCity.Concat(leadsFromSameCountry).Distinct();

            return filteredUsers;
        }

        private async Task<IEnumerable<string>> GetUsersExcludeUnindexedAsync(string personVertexId, string countryId, string cityId)
        {
            var leadsFromSameCity = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
            {
                LeadFilter.City,
                LeadFilter.AttributeGroup
            }, cityId);

            var sameCountryCount = (int)Math.Round((double)leadsFromSameCity.Count / 5);

            var leadsFromSameCountry = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
            {
                LeadFilter.Country20,
                LeadFilter.AttributeGroup
            }, countryId, cityId, sameCountryCount);

            var filteredUsers = leadsFromSameCity.Concat(leadsFromSameCountry).Distinct();

            return filteredUsers;
        }

        private async Task<IEnumerable<string>> GetUsersCountryCityOnlyAsync(string personVertexId, string countryId, string cityId)
        {
            var leadsFromSameCity = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
            {
                LeadFilter.City
            }, cityId);

            var sameCountryCount = (int)Math.Round((double)leadsFromSameCity.Count / 5);

            var leadsFromSameCountry = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
            {
                LeadFilter.Country20
            }, countryId, cityId, sameCountryCount);

            var filteredUsers = leadsFromSameCity.Concat(leadsFromSameCountry).Distinct();

            return filteredUsers;
        }

        private async Task<IEnumerable<string>> GetUsersCountryOnlyAsync(string personVertexId, string countryId)
        {
            var leadsFromSameCountry = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>
            {
                LeadFilter.Country
            }, countryId);

            var filteredUsers = leadsFromSameCountry;

            return filteredUsers;
        }

        private async Task<IEnumerable<string>> GetUsersWithoutFilterAsync(string personVertexId)
        {
            var leadsWithoutFilter = await _personRepository.GetLeadsAsync(personVertexId, new List<LeadFilter>());

            return leadsWithoutFilter;
        }

        private static double RateOfChange(IEnumerable<LeadCountsDTO> leadCounts)
        {
            if (!leadCounts.Any())
                return 0;

            double avgDiff = leadCounts.Average(d => d.Diff);
            double avgDays = leadCounts.Average(d => d.Days);

            var value = leadCounts.Sum(d => (d.Diff - avgDiff) * (d.Days - avgDays)) / leadCounts.Sum(d => Math.Pow(d.Days - avgDays, 2));

            if (Double.IsNaN(value) || Double.IsInfinity(value))
                return 0;

            return value;
        }

        #endregion
    }
}