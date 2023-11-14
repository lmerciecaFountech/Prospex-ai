using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/degree
    /// </summary>
    internal sealed class Degree : BaseModel
    {
        public string Type { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public string DegreeTypeName { get; set; }
        public string DegreeSubject { get; set; }
    }
}