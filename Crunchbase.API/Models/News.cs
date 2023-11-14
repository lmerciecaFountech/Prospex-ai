using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/press-reference
    /// </summary>
    internal sealed class News : BaseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostedOn { get; set; }
        public string Url { get; set; }
    }
}