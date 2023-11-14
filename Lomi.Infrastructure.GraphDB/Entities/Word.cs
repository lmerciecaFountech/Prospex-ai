using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Word : Entity
    {
        public Word(string value, int count, string source)
           : this(value, count, new List<string> { source })
        {

        }

        public Word(string value, int count, List<string> source)
        {
            Value = value;
            Count = count;
            Source = source;
        }

        public string Value { get; }
        public int Count { get; }
        public List<string> Source { get; }
    }
}