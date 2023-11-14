using Lomi.Infrastructure.GraphDB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class PersonName
    {
        //TODO Validation about empty values
        public PersonName(string fullName)
        {
            var fullnameComponents = fullName?.SafeSplit(' ');

            FirstName = fullnameComponents?.ElementAtOrDefault(0);
            LastName = fullnameComponents?.ElementAtOrDefault(1);
        }

        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
