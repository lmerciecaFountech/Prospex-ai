using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class BaseGremlin
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
    }
}