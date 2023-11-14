using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Generator.Models
{
    public class Usage
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public DateTime DateTime { get; set; }
        public string Time { get; set; }
        public string EventType { get; set; }
        public double CustomEvenWeight { get; set; }
    }
}