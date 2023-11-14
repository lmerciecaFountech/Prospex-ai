using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class PersonDnaLeadsDTO
    {
        public string PersonVertexId { get; set; }
        public string PersonProspexId { get; set; }
        public int DnaRDL { get; set; }
        public long NumberOfLeads { get; set; }
    }
}