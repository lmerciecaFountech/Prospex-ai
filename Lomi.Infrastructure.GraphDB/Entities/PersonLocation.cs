using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class PersonLocation
    {
        public static PersonLocation None()
        {
            return new PersonLocation();
        }

        public PersonLocation()
        {
            Home = Maybe<Location>.None;
            Work = Maybe<Location>.None;
            Other = new List<Maybe<Location>>();
        }

        public Maybe<Location> Home { get; set; }
        public Maybe<Location> Work { get; set; }
        public List<Maybe<Location>> Other { get; set; }

        public IEnumerable<Maybe<Location>> All => new List<Maybe<Location>>() { Home }
                                               .Concat(new List<Maybe<Location>>() { Work })
                                               .Concat(Other).Distinct();

        public string GeoLocation
        {
            get
            {
                if (Home.Value != null && Home.HasValue && Home.Value.Latitude != 0 && Home.Value.Longitude != 0)
                {
                    return string.Concat(Home.Value.Latitude, "-", Home.Value.Longitude);
                }
                else if (Work.Value != null && Work.HasValue && Work.Value.Latitude != 0 && Work.Value.Longitude != 0)
                {
                    return string.Concat(Work.Value.Latitude, "-", Work.Value.Longitude);
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
                if (Home.Value != null && Home.HasValue && !string.IsNullOrEmpty(Home.Value.ShortName))
                {
                    return Home.Value.ShortName;
                }
                else if (Home.Value != null && Home.HasValue && !string.IsNullOrEmpty(Home.Value.LongName))
                {
                    return Home.Value.LongName;
                }
                else if (Work.Value != null && Work.HasValue && !string.IsNullOrEmpty(Work.Value.ShortName))
                {
                    return Work.Value.ShortName;
                }
                else if (Work.Value != null && Work.HasValue && !string.IsNullOrEmpty(Work.Value.LongName))
                {
                    return Work.Value.LongName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}