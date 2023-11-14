using Lomi.Infrastructure.WordsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing.Interfaces
{
    public interface IWordsApi
    {
        double GetFrequencyValue(Phrase phrase);
        WordInfo GetWordInfo(Phrase phrase);
    }

    public interface IWikipediaApi
    {
        int GetOccurrencesCount(Phrase phrase);
    }

    public interface IPhrasesExternalValidator
    {
        HashSet<Phrase> Filter(IEnumerable<Phrase> phrases);
    }
}
