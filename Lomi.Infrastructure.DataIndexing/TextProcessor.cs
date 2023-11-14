using Lomi.Infrastructure.DataIndexing.Data;
using Lomi.Infrastructure.DataIndexing.Interfaces;
using Lomi.Infrastructure.WordsApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class TextProcessor
    {
        private static TextProcessor _textProcessor;
        private TextFilter textFilter;
        private PhrasesFactory phrasesFactory;
        private Sanitizer sanitizer;
        private IPhrasesExternalValidator externalValidator;
        private AlphaZeroOneLists alphaZeroOneList;

        public TextProcessor(TextFilter textFilter, PhrasesFactory phrasesFactory, Sanitizer sanitizer, IPhrasesExternalValidator externalValidator)
        {
            this.textFilter = textFilter;
            this.phrasesFactory = phrasesFactory;
            this.sanitizer = sanitizer;
            this.externalValidator = externalValidator;
        }

        public static TextProcessor Instance()
        {
            if (_textProcessor != null)
                return _textProcessor;

            var alphaZeroOneList = new AlphaZeroOneLists();
            SeedSanitizationAndBlacklist(alphaZeroOneList);
            var textFilter = new TextFilter(alphaZeroOneList.BlackList);
            var phrasesFactory = new PhrasesFactory();
            var sanitizer = new Sanitizer(alphaZeroOneList.SanitizationList);
            var externalValidator = new PhrasesExternalValidator();

            _textProcessor = new TextProcessor(textFilter, phrasesFactory, sanitizer, externalValidator);
            _textProcessor.alphaZeroOneList = alphaZeroOneList;

            var wordsApi = WordsAPI.Instance;
            return _textProcessor;

        }

        private static void SeedSanitizationAndBlacklist(AlphaZeroOneLists alphaZeroOneLists)
        {
            var blackList = new HashSet<string>(alphaZeroOneLists.BlackList);

            foreach (var file in Directory.GetFiles("BlackLists"))
            {
                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    blackList.Add(line);
                }
            }
            alphaZeroOneLists.BlackList = blackList.ToList();

            foreach (var file in Directory.GetFiles("SanitizationLists"))
            {
                var type = Path.GetFileNameWithoutExtension(file);
                var lines = File.ReadAllLines(file);
                var sanitizationType = alphaZeroOneLists.SanitizationList
                    .FirstOrDefault(x => x.Type == type);
                if (sanitizationType == null)
                {
                    sanitizationType = new DataIndexing.Sanitization(type, new List<string>());
                    alphaZeroOneLists.SanitizationList.Add(sanitizationType);
                }
                var sanitizations = new HashSet<string>(sanitizationType.Words);

                foreach (var line in lines)
                {
                    sanitizations.Add(line);
                }

                sanitizationType.Words = sanitizations.ToList();
            }
        }

        public async Task<HashSet<Phrase>> Process(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new HashSet<Phrase>();
            }

            await Task.CompletedTask;

            HashSet<Phrase> phrases = phrasesFactory.Create(text);
            HashSet<Phrase> filteredPhrases = textFilter.FilterOutBlackListed(new HashSet<Phrase>(phrases.Take(100)));
            HashSet<Phrase> sanitizedPhrases = SanitizePhrases(filteredPhrases);
            HashSet<Phrase> validPhrases = externalValidator.Filter(sanitizedPhrases);

            return validPhrases;
        }

        public async Task<HashSet<Phrase>> Process(IEnumerable<string> texts)
        {
            var phrases = new HashSet<Phrase>();

            if (texts == null)
            {
                return phrases;
            }

            foreach (var text in texts)
            {
                var textPhrases = await Process(text);
                foreach (var textPhrase in textPhrases)
                {
                    if (!string.IsNullOrWhiteSpace(textPhrase.Value?.Value))
                    {
                        phrases.Add(textPhrase);
                    }
                }
            }

            return phrases;
        }

        private HashSet<Phrase> SanitizePhrases(HashSet<Phrase> filteredPhrases)
        {
            HashSet<Phrase> sanitizedPhrases = new HashSet<Phrase>();

            foreach (var filteredPhrase in filteredPhrases)
            {
                var sanitizedPhrase = sanitizer.Sanitize(filteredPhrase);
                if (sanitizedPhrase.HasValue)
                {
                    sanitizedPhrases.Add(sanitizedPhrase.Value);
                }
            }

            return sanitizedPhrases;
        }
    }
}
