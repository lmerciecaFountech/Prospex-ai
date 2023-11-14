using Lomi.Infrastructure.DataIndexing.Interfaces;
using Lomi.Infrastructure.WordsApi;
using Lomi.Infrastructure.WordsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class WordsApiService : IWordsApi
    {
        public double GetFrequencyValue(Phrase phrase)
        {
            return WordsAPI.Instance.Search(phrase.ToString())?.Frequency?.Zipf ?? 0;
        }

        public WordInfo GetWordInfo(Phrase phrase)
        {
            return WordsAPI.Instance.Search(phrase.ToString());
        }
    }
}
