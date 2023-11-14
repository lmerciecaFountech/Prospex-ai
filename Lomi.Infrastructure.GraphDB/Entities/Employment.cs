using Lomi.Infrastructure.GraphDB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Employment
    {
        public static Maybe<Employment> Build(Maybe<Company> company, Maybe<EmploymentRole> role, DateTime? from, DateTime? to, bool isPrimary)
        {
            if (!company.HasValue && !role.HasValue)
            {
                return Maybe<Employment>.None;
            }
            else
            {
                List<string> ids = new List<string>();
                if (company.HasValue)
                {
                    ids.Add(company.Value.Name);
                }

                if (role.HasValue)
                {
                    ids.Add(role.Value.Title);
                }

                return Maybe.Some(new Employment(company, role, from, to, isPrimary, ids));
            }
        }

        private Employment(Maybe<Company> company, Maybe<EmploymentRole> role, DateTime? from, DateTime? to, bool isPrimary, List<string> ids)
        {
            Company = company;
            Role = role;
            From = from;
            To = to;
            IsPrimary = isPrimary;
        }

        public Maybe<Company> Company { get; }
        public Maybe<EmploymentRole> Role { get; }
        public DateTime? From { get; }
        public DateTime? To { get; }
        public bool IsPrimary { get; set; }
    }
}
