using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Company : Entity
    {
        public Company(VertexLabel label, 
                        Source source,
                       string dataSourceId,
                       string name,
                       string description,
                       Maybe<Industry> industry,
                       Maybe<Location> location)
        {
            SetId(dataSourceId, source);
            SourceId = dataSourceId;
            Name = name;
            Description = description;
            Industry = industry;
            Location = location;
            Label = label;
        }

        public Company(VertexLabel label,
                        Source source,
                       string dataSourceId,
                       string name,
                       Maybe<Industry> industry,
                       Maybe<Location> locationData) : this(label, source, dataSourceId, name, string.Empty, industry, locationData)
        {
        }

        public Prop<bool?> Active { get; set; }
        public Prop<VertexLabel> Label { get; set; }
        public Prop<string> SourceId;
        public Prop<string> ProspexId { get; set; }
        public Prop<string> Name { get; private set; }
        public Prop<string> Description { get; }
        public Prop<string> FacebookUrl { get; set; }
        public Prop<string> TwitterUrl { get; set; }
        public Prop<string> LinkedInUrl { get; set; }
        public Prop<string> CrunchbaseUrl { get; set; }
        public Prop<string> LogoUrl { get; set; }
        public Prop<string> Email { get; set; }
        public Prop<string> Phone { get; set; }
        public Prop<string> Phone2 { get; set; }
        public Prop<string> AddressPoBox { get; set; }
        public Prop<string> City { get; set; }
        public Prop<string> Country { get; set; }
        public Prop<string> Fax { get; set; }
        public Prop<string> PostalCode { get; set; }
        public Prop<string> State { get; set; }
        public Prop<string> Street { get; set; }
        public Prop<string> Street2 { get; set; }
        public Prop<string> Street3 { get; set; }
        public Prop<string> Region { get; set; }
        public Prop<string> Categories { get; set; }
        public Prop<string> Size { get; set; }
        public Prop<string> Website { get; set; }
        public Prop<int?> NumberOfEmployees;
        public Maybe<Industry> Industry { get; set; }
        public Maybe<Location> Location { get; set; }

        public string Geolocation
        {
            get
            {
                if (Location.HasValue && Location.HasValue && Location.Value.Latitude != 0 && Location.Value.Longitude != 0)
                {
                    return string.Concat(Location.Value.Latitude, "-", Location.Value.Longitude);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string LocationName
        {
            get
            {
                if (Location.HasValue && Location.HasValue && !string.IsNullOrEmpty(Location.Value.ShortName))
                {
                    return Location.Value.ShortName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        
    }
}