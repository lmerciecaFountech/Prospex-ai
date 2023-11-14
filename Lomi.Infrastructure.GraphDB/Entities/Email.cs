using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Email
    {
        public static Maybe<Email> From(string email)
        {
            return string.IsNullOrEmpty(email) ? Maybe<Email>.None : Maybe.Some(new Email(email));
        }

        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

    }
}