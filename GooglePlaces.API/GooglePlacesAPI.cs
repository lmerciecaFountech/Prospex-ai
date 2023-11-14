using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;
using GooglePlaces.API.Data;
using GooglePlaces.API.Enums;
using GooglePlaces.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlaces.API
{
    public class GooglePlacesAPI
    {
        private readonly string _key;
        private readonly PlacesTextSearchRequest _textSearchRequest;
        private readonly PlacesAutoCompleteRequest _placesAutoCompleteRequest;

        public GooglePlacesAPI(string key)
        {
            _key = key;
            _textSearchRequest = new PlacesTextSearchRequest
            {
                Key = _key
            };
            _placesAutoCompleteRequest = new PlacesAutoCompleteRequest
            {
                Key = _key
            };
        }

        public async Task<List<GeoLocation>> Autocomplete(string query, IEnumerable<AddressComponentType> types, IEnumerable<AddressComponent> otherAddressComponents)
        {
            var addressComponentTypes = types.ToList();

            _placesAutoCompleteRequest.Input = query;
            if (addressComponentTypes.Any(x => x == AddressComponentType.Administrative_Area_Level_3))// || x == AddressComponentType.Locality
            {
                _placesAutoCompleteRequest.Types = new List<RestrictPlaceType>()
                    {
                        RestrictPlaceType.Cities
                    };
            }
            else if (addressComponentTypes.Any(x => x == AddressComponentType.Locality || x == AddressComponentType.Sublocality ||
                x == AddressComponentType.Country || x == AddressComponentType.Administrative_Area_Level_1 ||
                x == AddressComponentType.Administrative_Area_Level_2))
            {
                _placesAutoCompleteRequest.Types = new List<RestrictPlaceType>()
                    {
                        RestrictPlaceType.Regions
                    };
            }
            else
            {
                _placesAutoCompleteRequest.Types = new List<RestrictPlaceType>()
                    {
                        RestrictPlaceType.Geocode
                    };
            }

            var response = GoogleApi.GooglePlaces.AutoComplete.Query(_placesAutoCompleteRequest);

            var predictions = response.Predictions
                .Where(prediction => prediction.Types.Count(type => addressComponentTypes.Any(component => component.ToString() == type.ToString())) > 1)
                .OrderByDescending(prediction => prediction.Types.Count(type => addressComponentTypes.Any(component => component.ToString() == type.ToString()))).ToList();

            if (predictions.Count > 1)
            {
                predictions = predictions.Where(x => x.Terms.All(y => otherAddressComponents.Any(z => y.Value == z.LongName || y.Value == z.ShortName))).ToList();
            }

            var parts = query.Split(',');

            if (predictions.Count == 0 && parts.Length > 2)
            {
                var name = parts.FirstOrDefault();
                var country = parts.LastOrDefault();

                var autocompleteResult = await Autocomplete(string.Join(",", name, country), addressComponentTypes, otherAddressComponents);

                return autocompleteResult;
            }

            var geoLocations = new List<GeoLocation>();

            foreach (var prediction in predictions)
            {
                var geolocation = await GetGeoLocation(prediction.PlaceId);
                if (geolocation != null)
                {
                    geoLocations.Add(geolocation);
                }
            }

            return geoLocations;
        }

        public async Task<List<GeoLocation>> Search(string query)
        {
            var geoLocations = new List<GeoLocation>();

            var response = ExecuteRequest(query);
            string previousQuery = query;

            while (!response.Results.Any())
            {
                query = query.RemoveFirstWord();

                // last word already searched
                if (string.Equals(previousQuery, query))
                {
                    break;
                }

                response = ExecuteRequest(query);
                previousQuery = query;
            }

            foreach (var textResult in response.Results)
            {
                var geolocation = await GetGeoLocation(textResult.PlaceId);
                if (geolocation != null)
                {
                    geoLocations.Add(geolocation);
                }
            }

            return geoLocations;
        }

        private PlacesTextSearchResponse ExecuteRequest(string query)
        {
            _textSearchRequest.Query = query;

            return GoogleApi.GooglePlaces.TextSearch.Query(_textSearchRequest);
        }

        public async Task<GeoLocation> GetGeoLocation(string placeId)
        {
            var detailsRequest = new PlacesDetailsRequest
            {
                Key = _key,
                PlaceId = placeId
            };

            try
            {
                var details = GoogleApi.GooglePlaces.Details.Query(detailsRequest).Result;
                var geolocation = new GeoLocation(details.PlaceId, details.Geometry.Location.Latitude,
               details.Geometry.Location.Longitude, details.UtcOffset, details.AddressComponents);

                await Task.CompletedTask;
                return geolocation;
            }
            catch (Exception ex)
            {

                throw;
            }





            


        }

    }
}
