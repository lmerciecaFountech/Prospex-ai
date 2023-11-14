using Lomi.Infrastructure.GraphDB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class TextFilter
    {
        private List<string> blackListWords;

        public TextFilter(List<string> blackList)
        {
            this.blackListWords = blackList;
        }

        public HashSet<Phrase> FilterOutBlackListed(HashSet<Phrase> phrases)
        {
            var filteredPhrases = phrases.Select(x => x.Remove(blackListWords)).Unwrap();
            var filteredSet = new HashSet<Phrase>(filteredPhrases);

            return filteredSet;
        }
    }
}
