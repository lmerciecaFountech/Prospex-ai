using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class Phrase : IEquatable<Phrase>
    {

        public Phrase(string value)
        {
            Value = new Word(value);
        }

        public Phrase(IEnumerable<string> words)
        {
            Value = new Word(string.Join(" ", words));
        }


        public Word Value { get; }
        public bool IsSanitized { get; set; }
        public bool IsExcluded { get; set; }
        public bool IsMarkedForWiki { get; set; }

        public Phrase Replace(string existing, string newWord)
        {
            List<string> newWords = new List<string>();

            List<string> list = Value.Split().Aggregate(newWords, (acc, next) =>
            {
                if (next.Equals(newWord))
                {
                    acc.Add(newWord);
                }
                else
                {
                    acc.Add(next);
                }
                return acc;
            });

            return new Phrase(newWords);
        }


        public Maybe<Phrase> Remove(List<string> values)
        {
            List<string> newWords = new List<string>();

            List<string> list = Value.Split().Aggregate(newWords, (acc, next) =>
            {
                if (!values.Contains(next))
                {
                    acc.Add(next);
                }

                return acc;
            });

            return newWords.Count > 0 ? Maybe.Some(new Phrase(newWords)) : Maybe<Phrase>.None;
        }

        public bool Equals(Phrase other)
        {
            return Value.Equals(other.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            Phrase phrase = obj as Phrase;

            if (phrase == null)
            {
                return false;
            }

            return Equals(phrase);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
