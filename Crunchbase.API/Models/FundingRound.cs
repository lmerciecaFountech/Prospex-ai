using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/funding-round
    /// </summary>
    internal sealed class FundingRound : BaseModel
    {
        public string FundingType { get; set; }
        public string Series { get; set; }
        public string SeriesQualifier { get; set; }
        public DateTime AnnouncedOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public int MoneyRaised { get; set; }
        public string MoneyRaisedCurrencyCode { get; set; }
        public int MoneyRaisedUsd { get; set; }
        public int TargetMoneyRaised { get; set; }
        public string TargetMoneyRaisedCurrencyCode { get; set; }
        public int TargetMoneyRaisedUsd { get; set; }
        public int PreMoneyValuation { get; set; }
        public string PreMoneyValucationCurrencyCode { get; set; }
        public int PreMoneyValuationUsd { get; set; }
    }
}