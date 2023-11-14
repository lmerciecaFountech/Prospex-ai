using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Industry
    {
        public string Value { get; private set; }

        private Industry(string value)
        {
            Value = value.ToLower();
        }

        public static Maybe<Industry> From(string name)
        {

            if (!string.IsNullOrEmpty(name))
            {
                return Maybe<Industry>.Some(new Industry(name));
            }
            else
            {
                return Maybe<Industry>.None;
            }
        }
    }
}