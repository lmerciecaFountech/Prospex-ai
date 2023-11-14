using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class Sanitizer
    {
        private Dictionary<Phrase, Phrase> checkedPhrases = new Dictionary<Phrase, Phrase>();
        private List<Tuple<string, string>> sanitizationValuesList;
        private RegexOptions regexOptions = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

        public Sanitizer(List<Sanitization> sanitizationList)
        {

            sanitizationValuesList = (from item in sanitizationList
                                      from words in item.Words
                                      select Tuple.Create(item.Type, words)).ToList();

            sanitizationValuesList.Add(Tuple.Create($"<Number>", "\\d+"));
        }

        public Maybe<Phrase> Sanitize(Phrase phrase)
        {
            Phrase sanitizedPhrase = null;
            if (checkedPhrases.TryGetValue(phrase, out sanitizedPhrase))
            {
                return Maybe.Some(sanitizedPhrase);
            }
            else
            {
                Maybe<Phrase> result = Get(phrase);
                if (result.HasValue)
                {
                    checkedPhrases[phrase] = result.Value;
                }

                return result;
            }
        }

        private Maybe<Phrase> Get(Phrase phrase)
        {

            var sanitizedItems = sanitizationValuesList.Where(k => k.Item2.Equals(phrase.ToString(), StringComparison.InvariantCultureIgnoreCase));
            if(sanitizedItems != null && sanitizedItems.Any())
            {
                var sanitizedItem = sanitizedItems.FirstOrDefault();
                var sanitizedValue = $"<{sanitizedItem.Item1}>";
                var sanitizedPhrase = new Phrase(sanitizedValue);
                sanitizedPhrase.IsSanitized = true;
                return Maybe.Some(sanitizedPhrase);
            }
            else
            {
                return Maybe.Some(phrase);
            }

            //foreach (var item in sanitizationValuesList)
            //{
            //    //if(string.Equals(phrase.ToString(), item.Item2, StringComparison.InvariantCultureIgnoreCase))
            //    //{
            //    //    return Maybe<Phrase>.None();
            //    //}
            //    string pattern = $@"\b{Regex.Escape(item.Item2.ToString())}\b";
            //    if (Regex.IsMatch(phrase.ToString(), pattern, regexOptions))
            //    {
            //        phrase.IsSanitized = true;

            //        string replacement = $"<{item.Item1}>";

            //        string sanitizedValue = Regex.Replace(phrase.ToString(), pattern, replacement, regexOptions);

            //        var sanitizedPhrase = new Phrase(sanitizedValue);
            //        sanitizedPhrase.IsSanitized = true;

            //        return Maybe.Some(sanitizedPhrase);
            //    }
            //}

            //return Maybe.Some(phrase);
        }
    }
}
