using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Location : Entity
    {
        private Prop<string> _placeId;
        private bool _isSelected;

        public Location(string placeId, double longitude, double latitude, string longName, string shortName,
            VertexLabel label, int utcOffset, IEnumerable<string> locationTypes = null, bool isExisting = false)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Longitude = longitude;
            LongName = longName;
            ShortName = shortName;
            Label = label;
            IsExisting = isExisting;
            UtcOffset = utcOffset;
            if (locationTypes != null)
            {
                LocationType = locationTypes.FirstOrDefault(x => x != "Political");
            }
        }

        private bool IsExisting { get; set; }
        public Prop<VertexLabel> Label { get; set; }
        public Prop<string> PlaceId
        {
            get => _placeId;
            set
            {
                _placeId = value;
                SetId(_placeId);
            }
        }
        public Prop<string> LongName { get; set; }
        public Prop<string> ShortName { get; set; }
        public Prop<double> Latitude { get; set; }
        public Prop<double> Longitude { get; set; }
        public Prop<int> UtcOffset { get; set; }
        public IList<Location> Parents { get; } = new List<Location>();
        public Prop<string> LocationType { get; set; }
        public bool CanBeAdded => HasCountryOrExisting(Parents);

        private bool HasCountryOrExisting(IList<Location> parents)
        {
            if (LocationType == "Country" || IsExisting || parents.Any(x => x.LocationType == "Country" || x.IsExisting))
            {
                return true;
            }
            else
            {
                return parents.Any(x => HasCountryOrExisting(x.Parents));
            }
        }

        public bool HasPlace(string placeId, Location child = null)
        {
            if (child == null)
            {
                child = this;

                if (child.PlaceId == placeId)
                    return true;
            }

            return child.Parents.Any(x => x.PlaceId == placeId || HasPlace(placeId, x));
        }

        public bool IsSelected()
        {
            return _isSelected;
        }

        public void IsSelected(bool value)
        {
            _isSelected = value;
        }
    }

    public class LocationId
    {
        public LocationId(string placeId)
        {
        }

        public string PlaceId { get; set; }
    }
}