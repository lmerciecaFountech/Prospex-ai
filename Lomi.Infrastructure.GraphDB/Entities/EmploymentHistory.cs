using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class EmploymentHistory
    {
        public static EmploymentHistory None()
        {
            return new EmploymentHistory(new List<Employment>());
        }

        public EmploymentHistory(Employment employment)
        {
            EmploymentList = new List<Employment> { employment };
        }

        public EmploymentHistory(List<Employment> employmentList)
        {
            EmploymentList = employmentList;
        }

        public List<Employment> EmploymentList { get; }
    }
}
