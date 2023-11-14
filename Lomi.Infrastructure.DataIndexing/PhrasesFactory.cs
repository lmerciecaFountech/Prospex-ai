using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class PhrasesFactory
    {
        public HashSet<Phrase> Create(string text)
        {
            List<string> words = SplitIntoWords(text);

            return Create(words);
        }

        public HashSet<Phrase> Create(List<string> words)
        {
            List<Phrase> phrases = new List<Phrase>();
            //for (int i = 0; i < words.Count; i++)
            //{
            //    phrases.AddRange(CreatePhrases(words.Skip(i)));
            //}

            phrases.AddRange(CreatePhrases(words));

            return new HashSet<Phrase>(phrases);
        }

        public List<Phrase> CreatePhrases(IEnumerable<string> words)
        {
            List<Phrase> singleWordPhrases = CreatePhrases(words, 1);
            //List<Phrase> twoWordsPhrase = CreatePhrases(words, 2);
            //List<Phrase> threeWordsPhrase = CreatePhrases(words, 3);

            List<Phrase> phrases = new List<Phrase>();
            phrases.AddRange(singleWordPhrases);
            //phrases.AddRange(twoWordsPhrase);
            //phrases.AddRange(threeWordsPhrase);

            return phrases;
        }


        public List<Phrase> CreatePhrases(IEnumerable<string> words, int groupCount)
        {
            List<List<string>> wordsList = new List<List<string>>();
            List<string> seed = null;

            words.Aggregate(seed, (acc, next) =>
            {
                if (acc == null)
                {
                    acc = new List<string>();
                    wordsList.Add(acc);
                }

                acc.Add(next);

                return acc.Count == groupCount ? null : acc;
            });

            return wordsList.Select(x => new Phrase(x)).ToList();
        }

        public List<string> SplitIntoWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<string>();
            }

            var words = Regex.Split(text, @"\s").Select(x => TrimNonWordChars(x)).Where(x => !string.IsNullOrWhiteSpace(x));
            int dummy;
            return words.ToList().Where(w => !int.TryParse(w, out dummy)).ToList();
        }

        private string TrimNonWordChars(string s)
        {
            var match = Regex.Match(s, @"\b.*\b");

            return (match.Success) ? match.Value : string.Empty;
        }
    }
}
