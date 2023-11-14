using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/investor-investment
    /// </summary>
    internal sealed class Investment : BaseModel
    {
        public string Type { get; set; }
        public int MoneyInvested { get; set; }
        public string MoneyInvestedCurrencyCode { get; set; }
        public int MoneyInvestedUsd { get; set; }
        public bool IsLeadInvestor { get; set; }
        public DateTime AnnouncedOn { get; set; }
    }
}