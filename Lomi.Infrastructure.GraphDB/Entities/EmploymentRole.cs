using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class EmploymentRole
    {
        private EmploymentRole(string title)
        {
            Title = title.ToLower();
        }

        public static Maybe<EmploymentRole> From(string title)
        {
            return string.IsNullOrEmpty(title) ? Maybe<EmploymentRole>.None : Maybe.Some(new EmploymentRole(title));
        }

        public string Title { get; private set; }
    }
}
