using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/acquisition
    /// </summary>
    internal sealed class Acquisition : BaseModel
    {
        public int Price { get; set; }
        public string PriceCurrencyCode { get; set; }
        public int PriceUsd { get; set; }
        public string PaymentType { get; set; }
        public string AcquisitionType { get; set; }
        public string AcquisitionStatus { get; set; }
        public string DispositionOfAcquired { get; set; }
        public DateTime AnnouncedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public string ApiUrl { get; set; }
        public int Rank { get; set; }
    }
}