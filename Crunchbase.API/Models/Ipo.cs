using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/ipo
    /// </summary>
    internal sealed class Ipo : BaseModel
    {
        public DateTime WentPublicOn { get; set; }
        public string StockExchangeSymbol { get; set; }
        public string StockSymbol { get; set; }
        public int SharesSold { get; set; }
        public float OpeningSharePrice { get; set; }
        public string OpeningSharePriceCurrencyCode { get; set; }
        public float OpeningSharePriceUsd { get; set; }
        public int OpeningValuation { get; set; }
        public string OpeningValuationCurrencyCode { get; set; }
        public int OpeningValuationUsd { get; set; }
        public int MoneyRaised { get; set; }
        public string MoneyRaisedCurrencyCode { get; set; }
        public int MoneyRaisedUsd { get; set; }
    }
}