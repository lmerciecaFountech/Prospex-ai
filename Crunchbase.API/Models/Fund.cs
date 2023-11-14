using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/fund-raise
    /// </summary>
    internal sealed class Fund : BaseModel
    {
        public string Name { get; set; }
        public DateTime AnnouncedOn { get; set; }
        public int MoneyRaised { get; set; }
        public string MoneyRaisedCurrencyCode { get; set; }
        public int MoneyRaisedUsd { get; set; }
    }
}