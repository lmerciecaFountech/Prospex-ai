using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/web-presence
    /// </summary>
    internal sealed class Website : BaseModel
    {
        public string WebsiteType { get; set; }
        public string Url { get; set; }
        public string WebsiteName { get; set; }
    }
}