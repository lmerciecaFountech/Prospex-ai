using GooglePlaces.API;
using GooglePlaces.API.Data;
using GooglePlaces.API.Enums;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
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
    public class GooglePlaceService : IGooglePlaceService
    {
        private GooglePlacesAPI _googlePlacesApi;
        private readonly ILocationRepository _locationRepository;

        public GooglePlaceService()
        {
            //_googlePlacesApi = new GooglePlacesAPI("AIzaSyC1SJrFS6Ik1MDownWQd8YHuKNuxShcnfw");
            _googlePlacesApi = new GooglePlacesAPI("AIzaSyBSFMtkxeCgSapvlcUWZKgSrfxZzn6Bq04");
            _locationRepository = new LocationRepository();
        }

        public async Task<Maybe<Location>> GetLocationByPlaceIdAsync(string placeId, EdgeLabel label)
        {
            if (_googlePlacesApi == null || string.IsNullOrWhiteSpace(placeId))
                return Maybe<Location>.None;

            GeoLocation place;
            Location location = null;

            try
            {
                place = await _googlePlacesApi.GetGeoLocation(placeId);
                location = await GeoLocationToLocation(place, null, label);
                location = TrimLocation(location);
            }
            catch (Exception ex)
            {

            }

            return location != null
                ? Maybe.Some(location)
                : Maybe<Location>.None;
        }

        public async Task<List<Maybe<Location>>> GetLocationsAsync(string address, EdgeLabel label)
        {
            var locations = new List<Maybe<Location>>();

            if (_googlePlacesApi == null || string.IsNullOrWhiteSpace(address))
                return locations;

            var places = (await _googlePlacesApi.Search(address))
                .Take(1) // Temporary
                .ToList();

            foreach (var place in places)
            {
                var location = await GeoLocationToLocation(place, null, label);

                location = TrimLocation(location);

                var locationItem = location == null ? Maybe<Location>.None : Maybe.Some(location);

                locations.Add(locationItem);
            }

            return locations;

        }

        private async Task<Location> GeoLocationToLocation(GeoLocation place, Location child, EdgeLabel label)
        {
            Location location = null;
            var locationViewModel = await _locationRepository.GetByPlaceIdAsync(place.PlaceId);

            if (locationViewModel != null)
            {
                location = locationViewModel;
                child?.Parents.Add(location);
            }
            else
            {
                var component = place.AddressComponents?.FirstOrDefault();

                location = new Location(place.PlaceId, place.Latitude, place.Longitude, component?.LongName, component?.ShortName,
                    VertexLabel.Location, place.UtcOffset, component?.Types?.Select(x => x.ToString()).ToList());

                child?.Parents.Add(location);

                var i = 1;
                bool placeAlreadyExists;

                do
                {
                    placeAlreadyExists = true;

                    var names = place.AddressComponents?.Skip(i++)
                        .Where(x => !x.Types.Any(y => y == AddressComponentType.Postal_Code || y == AddressComponentType.Street_Number))
                        .Select(x => x.LongName).ToList();

                    if (names == null || names.Count() == 0)
                        break;

                    var nextComponent = place.AddressComponents.Skip(i - 1).FirstOrDefault();

                    if (nextComponent == null)
                        break;

                    IEnumerable<GeoLocation> places2 = null;

                    //if (nextComponent.Types.Any(x => (int)x > 5 && (int)x < 20 || x == AddressComponentType.Postal_Town))
                    //{
                    places2 = await _googlePlacesApi.Autocomplete(string.Join(",", names), nextComponent?.Types, place.AddressComponents.Skip(i - 2));
                    //}

                    //places2 = await _googlePlacesApi.Autocomplete(string.Join(",", names), nextComponent?.Types, place.AddressComponents.Skip(i - 2));

                    //if (!places2?.Any() ?? true)
                    //{
                    //    places2 = await _googlePlacesApi.Search(string.Join(",", names));
                    //}
                    
                    

                    if (places2.Any())
                        places2 = places2.Take(1); // Temporary

                    //places2 = places2.Take(1).ToList(); // TODO: Use all locations

                    if (!places2.Any())
                        continue;

                    placeAlreadyExists = places2.Any(place2 => child != null && child.HasPlace(place2.PlaceId));

                    if (!placeAlreadyExists)
                    {
                        foreach (var place2 in places2.Where(place2 => place2.PlaceId != place.PlaceId))
                        {
                            await GeoLocationToLocation(place2, location, EdgeLabel.Belongs);
                        }
                    }

                } while (placeAlreadyExists);
            }

            return location;
        }

        private Location TrimLocation(Location location)
        {
            if (location.LocationType == "Street_Number" || location.LocationType == "Route")
            {
                var temporaryLocation = location.Parents.FirstOrDefault(); // Temporary

                return TrimLocation(temporaryLocation);
            }

            return location;
        }
    }
}
