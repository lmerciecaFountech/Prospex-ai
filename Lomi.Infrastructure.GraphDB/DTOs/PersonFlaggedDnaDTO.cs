using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class PersonFlaggedDnaDTO
    {
        public string PersonVertexId { get; set; }
        public int PersonUtcOffset { get; set; }
        public string DnaVertexId { get; set; }
        //Dna recomendation engine last updated
        public long DnaReLastUpdatedAt { get; set; }
        //Dna required daily leads
        public int DnaRDL { get; set; }
        public long NumberOfLeads { get; set; }
    }
}