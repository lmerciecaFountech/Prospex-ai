using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.WordsApi.Models
{
    public class Syllables
    {
        public long Count { get; set; }
        public List<string> List { get; set; }
    }
}