using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class EducationInfo
    {
        public EducationInfo(List<string> subjects, string school, List<string> classmates, string year)
        {
            Subjects = subjects;
            School = school;
            Classmates = classmates;
            Year = year;
        }

        public EducationInfo(string subject, string school, string year) : this(new List<string> { subject }, school, new List<string>(), year)
        {

        }

        public List<string> Subjects { get; private set; }
        public string School { get; private set; }
        public List<string> Classmates { get; private set; }
        public string Year { get; private set; }
    }
}
