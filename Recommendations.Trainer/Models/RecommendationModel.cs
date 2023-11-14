using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Trainer.Models
{
    public class RecommendationModel
    {
        public Guid? Id { get; set; }
        public bool IsSucceeded { get; set; }
    }
}