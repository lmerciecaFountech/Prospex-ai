using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/organizationsummary
    /// </summary>
    internal sealed class OrganizationSummary : BaseModel
    {
        public string Name { get; set; }
        public string PrimaryRole { get; set; }
        public string ShortDescription { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Domain { get; set; }
        public string HomePageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CountryCode { get; set; }
        public string StockExchange { get; set; }
        public string StockSymbol { get; set; }
    }
}