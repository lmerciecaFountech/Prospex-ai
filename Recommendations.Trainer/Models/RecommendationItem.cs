using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Trainer.Models
{
    public class RecommendationItem
    {
        public string Id { get; set; }
        public double? Score { get; set; }
    }
}