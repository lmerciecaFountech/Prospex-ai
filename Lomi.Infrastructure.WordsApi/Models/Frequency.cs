using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.WordsApi.Models
{
    public class Frequency
    {
        public double Zipf { get; set; }
        public double PerMillion { get; set; }
        public double Diversity { get; set; }
    }
}