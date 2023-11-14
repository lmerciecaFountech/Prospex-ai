using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Service.Interfaces;
using Lomi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Factories
{
    public class PersonFactory
    {
        private readonly IGooglePlaceService _googlePlaceService;

        public PersonFactory()
        {
            _googlePlaceService = new GooglePlaceService();
        }

        public async Task<Person> Create(AccountDTO account)
        {
            var personName = new PersonName(account.FirstName, account.LastName);
            var personLocationData = await GetLocationData(account);
            var id = $"{Source.Onboarding.Value}{nameof(Person)}{account.Id}";
            var person = new Person(
                Source.Onboarding,
                id,
                personName,
                Email.From(account.Email),
                GetGender(account.Gender),
                AgeCategoryHelper.From(account.DateOfBirth),
                EmploymentHistory.None(),
                personLocationData,
                Occupations.None(),
                Skills.None(),
                EducationInfoHistory.None(),
                account.ImageUri,
                new List<string>());

            person.SetId(account.Id.ToString(), Source.Onboarding);
            person.LomiId = Convert.ToString(GuidHelper.Create(GuidHelper.DnsNamespace, account.Id));
            person.ProspexId = account.Id;
            person.Birthdate = account.DateOfBirth?.Ticks;
            person.IsLocked = account.IsLocked;
            person.ProfileCompletion = account.ProfileCompletion;
            person.UtcOffset = TimezoneHelper.GetUtcOffset(personLocationData);
            return person;
        }

        public async Task<Person> Create(IdealClientDTO idealClient)
        {
            await Task.CompletedTask;
            return null;
        }

        private async Task<PersonLocation> GetLocationData(AccountDTO account)
        {
            var personLocationData = new PersonLocation();

            var otherLocation = await _googlePlaceService.GetLocationByPlaceIdAsync(account.PlaceId, EdgeLabel.In);

            if (!otherLocation.HasValue)
            {
                var addressComponents = new string[] { account.City, account.Country };
                var formattedAddress = string.Join(",", addressComponents.Where(x => x != null));
                List<Maybe<Location>> otherLocation2 = null;
                if (!string.IsNullOrWhiteSpace(formattedAddress))
                {
                    otherLocation2 = await _googlePlaceService.GetLocationsAsync(formattedAddress, EdgeLabel.In);
                }

                if (otherLocation2 == null && otherLocation2?.FirstOrDefault() == null)
                {
                    var locations = otherLocation.HasValue
                        ? account.Locations.Where(x => x.PlaceId != otherLocation.Value?.PlaceId)
                        : account.Locations;

                    var selectedLocations = new List<Maybe<Location>>();

                    if (locations != null && locations.Any())
                    {
                        foreach (var location in locations)
                        {
                            if (!string.IsNullOrWhiteSpace(location.PlaceId))
                            {
                                var possibleLocation = await _googlePlaceService.GetLocationByPlaceIdAsync(location.PlaceId, EdgeLabel.WorksIn);
                                possibleLocation.Value?.IsSelected(true);
                                selectedLocations.Add(possibleLocation);
                            }
                            else if (!string.IsNullOrWhiteSpace(location.Name))
                            {
                                var possibleLocations = await _googlePlaceService.GetLocationsAsync(location.Name, EdgeLabel.WorksIn);
                                possibleLocations.FirstOrDefault().Value?.IsSelected(true);
                                selectedLocations.AddRange(possibleLocations);
                            }
                        }
                    }

                    personLocationData.Other.AddRange(selectedLocations);
                }
                else
                {
                    personLocationData.Other.Add(otherLocation2.FirstOrDefault());
                }
            }
            else
            {
                personLocationData.Other.Add(otherLocation);
            }

            await Task.CompletedTask;
            return personLocationData;
        }

        private Gender GetGender(Gender? gender)
        {
            if (gender == Gender.Female)
                return Gender.Female;
            else if (gender == Gender.Male)
                return Gender.Male;
            else
                return Gender.Unknown;
        }
    }
}
