using Lomi.Infrastructure.WordsApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using Newtonsoft.Json;

namespace Lomi.Infrastructure.WordsApi
{
    public class WordsAPI
    {
        private static readonly Lazy<WordsAPI> lazy = new Lazy<WordsAPI>(() => new WordsAPI());
        private readonly string DATABASE_FILENAME = "wordsapi_list.json";
        private static string FilePath { get; set; }
        private JObject _words;

        public static WordsAPI Instance { get { return lazy.Value; } }

        private WordsAPI()
        {
            FilePath = FilePath ?? GetPath();

            using (StreamReader file = File.OpenText(FilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                // Loading the complete JSON file into memory
                _words = (JObject)JToken.ReadFrom(reader);
            }
        }

        private string GetPath()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATABASE_FILENAME);

            if (File.Exists(path))
                return path;

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Debug", DATABASE_FILENAME);

            if (File.Exists(path))
                return path;

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", DATABASE_FILENAME);

            if (File.Exists(path))
                return path;

            return null;
        }

        public WordInfo Search(string word)
        {
            JToken jWord = null;
            _words.TryGetValue(word?.ToLower(), out jWord);

            if (jWord != null)
            {
                return jWord.ToObject<WordInfo>();
            }
            else
            {
                var pluralizationService = PluralizationService.CreateService(new CultureInfo("en-US", false));
                var singularForm = pluralizationService.Singularize(word);
                if (singularForm != word)
                {
                    return Search(singularForm);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}