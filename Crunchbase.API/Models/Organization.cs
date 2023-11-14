using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/organization
    /// </summary>
    internal sealed class Organization : BaseModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ProfileImageUrl { get; set; }
        public string PrimaryRole { get; set; }
        public bool RoleCompany { get; set; }
        public bool RoleInvestor { get; set; }
        public bool RoleGroup { get; set; }
        public bool RoleSchool { get; set; }
        public DateTime FoundedOn { get; set; }
        public bool IsClosed { get; set; }
        public DateTime ClosedOn { get; set; }
        public int NumEmployeesMin { get; set; }
        public int NunEmployeesMax { get; set; }
        public int TotalFundingUsd { get; set; }
        public string StockExchange { get; set; }
        public string StockSymbol { get; set; }
        public int NumberOfInvestments { get; set; }
        public string HomePageUrl { get; set; }
        public string InvestorType { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public int Rank { get; set; }
    }
}