using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing.Data
{
    public class AlphaZeroOneLists
    {
        public AlphaZeroOneLists()
        {
            BlackList = new List<string>();
            SanitizationList = new List<Sanitization>();
        }

        public List<string> BlackList { get; set; }
        public List<Sanitization> SanitizationList { get; set; }
    }
}
