using Lomi.Infrastructure.WordsApi.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.WordsApi.Models
{
    public class WordInfo
    {
        public List<WordDefinition> Definitions { get; set; }

        public Syllables Syllables { get; set; }

        public Rhymes Rhymes { get; set; }

        [JsonConverter(typeof(FrequencyConverter))]
        public Frequency Frequency { get; set; }

        [JsonConverter(typeof(PronunciationConverter))]
        public Pronunciation Pronunciation { get; set; }

        public RhymePatterns RhymePatterns { get; set; }

        public long Letters { get; set; }

        public long Sounds { get; set; }
    }
}