using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class EducationInfoHistory
    {
        public static EducationInfoHistory None()
        {
            return new EducationInfoHistory();
        }

        private EducationInfoHistory()
        {
            EducationList = new List<EducationInfo>();
        }

        public EducationInfoHistory(EducationInfo info)
        {
            EducationList = new List<EducationInfo>() { info };
        }

        public EducationInfoHistory(IEnumerable<EducationInfo> info)
        {
            EducationList = info.ToList();
        }

        public List<EducationInfo> EducationList { get; private set; }
    }
}
