using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.DataIndexing
{
    public class Word : IEquatable<Word>
    {
        public Word(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public List<string> Split()
        {
            return Value.Split(' ').ToList();
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(Word other)
        {
            return string.Equals(Value, other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            Word word = obj as Word;
            if (word == null)
            {
                return false;
            }

            return Equals(word);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
