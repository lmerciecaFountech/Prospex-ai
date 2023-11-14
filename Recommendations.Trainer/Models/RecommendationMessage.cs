using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Trainer.Models
{
    public class RecommendationMessage
    {
        public string PersonId { get; set; }
        public string DnaId { get; set; }
        public string ModelId { get; set; }
        public DateTime FromDate { get; set; }
        public int RecommendationCount { get; set; }
    }
}