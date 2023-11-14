using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/job
    /// </summary>
    internal sealed class Job : BaseModel
    {
        public string Title { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
        public string JobType { get; set; }
    }
}