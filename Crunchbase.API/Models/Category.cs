using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/category
    /// </summary>
    internal sealed class Category : BaseModel
    {
        public string Name { get; set; }
    }
}