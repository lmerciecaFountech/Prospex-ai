using Lomi.Infrastructure.DataIndexing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class PhrasesExternalValidator : IPhrasesExternalValidator
    {
        private Dictionary<string, bool> checkedPhrases = new Dictionary<string, bool>();
        private readonly string[] excludePos = new[]
        {
            "definite article",
            "adverb",
            "conjunction",
            "preposition",
            "pronoun"
        };
        private IWordsApi _wordsApi;
        private IWikipediaApi _wikipediaApi;

        public PhrasesExternalValidator(IWordsApi wordsApi, IWikipediaApi wikipediaApi)
        {
            _wordsApi = wordsApi;
            _wikipediaApi = wikipediaApi;
        }

        public PhrasesExternalValidator()
        {
            _wordsApi = new WordsApiService();
            //wikipediaApi = new WikipediaService();
        }

        public HashSet<Phrase> Filter(IEnumerable<Phrase> phrases)
        {
            var filteredPhrases = phrases.Where(x => !DoExcludePhrase(x)).ToList();

            return new HashSet<Phrase>(filteredPhrases);
        }

        private bool DoExcludePhrase(Phrase phrase)
        {
            if (phrase.IsSanitized && phrase.Value.Split().Count == 1)
                return false;

            if (phrase.IsExcluded)
                return false;

            var doExclude = false;

            if (phrase.Value?.Value != null && !checkedPhrases.TryGetValue(phrase?.Value?.Value, out doExclude))
            {
                var wordInfo = _wordsApi.GetWordInfo(phrase);

                if (wordInfo == null) return false;

                double frequency = wordInfo.Frequency?.Zipf ?? 0;
                doExclude = (frequency > 0 && frequency < 2.0) || frequency > 6.0 ||
                            (wordInfo.Definitions?.All(definition => excludePos.Contains(definition.PartOfSpeech)) ?? false);

                phrase.IsMarkedForWiki = frequency == 0 && !phrase.IsSanitized;

                if (!checkedPhrases.ContainsKey(phrase?.Value?.Value))
                {
                    try
                    {
                        checkedPhrases.Add(phrase?.Value?.Value, doExclude);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return doExclude;
        }
    }
}
