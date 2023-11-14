using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class Sanitization
    {
        public Sanitization()
        {

        }

        public Sanitization(string type, List<string> words)
        {
            Type = type;
            Words = words;
        }

        public string Type { get; set; }
        public List<string> Words { get; set; }
    }
}
