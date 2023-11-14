using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/image-asset
    /// </summary>
    internal sealed class Image : BaseModel
    {
        public string Type { get; set; }
        public string ContentType { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int FileSize { get; set; }
    }
}