using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
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
    public class CompanyFactory
    {

        private readonly IGooglePlaceService _googlePlaceService;

        public CompanyFactory()
        {
            _googlePlaceService = new GooglePlaceService();
        }

        public async Task<Company> Create(CompanyDTO prospexCompany)
        {
            if (prospexCompany == null)
                return null;

            var industry = string.IsNullOrWhiteSpace(prospexCompany?.Description)
                ? Maybe<Industry>.None
                : Industry.From(prospexCompany.Description);

            var locationData = await GetLocationData(prospexCompany);
            var id = $"{Source.Onboarding.Value}{nameof(Company)}{prospexCompany.Id.ToString()}";
            var company = new Company(VertexLabel.Company, Source.Onboarding, id, prospexCompany.Name, prospexCompany.Description, industry, locationData);
            
            company.SetId(prospexCompany.Id.ToString(), Source.Onboarding);
            company.Active = prospexCompany.Active;
            company.Size = prospexCompany.CompanyType?.Name;
            company.Email = prospexCompany.ContactEmail;
            company.Country = prospexCompany.Country;
            company.City = prospexCompany.City;
            company.Region = prospexCompany.Region;
            company.PostalCode = prospexCompany.PostCode;
            company.Street = prospexCompany.AddressLine1;
            company.Street2 = prospexCompany.AddressLine2;
            company.Phone = prospexCompany.ContactTelephoneNumber;
            company.LogoUrl = prospexCompany.LogoUrl;
            company.Website = prospexCompany.Website;
            return company;
        }

        #region Private Methods

        private async Task<Maybe<Location>> GetLocationData(CompanyDTO prospexCompany)
        {
            var place = prospexCompany.Locations?.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.PlaceId));

            if (place != null)
            {
                var workLocation = await _googlePlaceService.GetLocationByPlaceIdAsync(place.PlaceId, EdgeLabel.In);

                if (workLocation.HasValue)
                {
                    return workLocation;
                }
            }

            //var addressComponents = new string[] { prospexCompany.AddressLine1, prospexCompany.AddressLine2, prospexCompany.Region, prospexCompany.City, prospexCompany.Country };

            var addressComponents = new string[] { prospexCompany.City, prospexCompany.Country };
            var formattedAddress = string.Join(",", addressComponents.Where(x => x != null));
            var workLocations = await _googlePlaceService.GetLocationsAsync(formattedAddress, EdgeLabel.In);
            return workLocations?.FirstOrDefault() != null
                    ? workLocations.FirstOrDefault()
                    : Maybe<Location>.None;   
        }

        #endregion
    }
}
