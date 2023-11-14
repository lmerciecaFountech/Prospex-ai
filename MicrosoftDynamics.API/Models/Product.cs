using MicrosoftDynamics.API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDynamics.API.Models
{
    public class Product
    {
        [JsonProperty("@odata.etag")]
        public string ODataEtag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("producttypecode")]
        public ProductTypeCode? ProductTypeCode { get; set; }

        [JsonProperty("producturl")]
        public string ProductUrl { get; set; }

        [JsonProperty("suppliername")]
        public string SupplierName { get; set; }

        [JsonProperty("validfromdate")]
        public DateTimeOffset? ValidFromDate { get; set; }

        [JsonProperty("validtodate")]
        public DateTimeOffset? ValidToDate { get; set; }

        [JsonProperty("vendorid")]
        public string VendorId { get; set; }

        [JsonProperty("vendorname")]
        public string VendorName { get; set; }

        [JsonProperty("createdon")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("entityimage_url")]
        public string EntityImageUrl { get; set; }

        [JsonProperty("versionnumber")]
        public long VersionNumber { get; set; }

        [JsonProperty("productid")]
        public string ProductId { get; set; }
    }
}