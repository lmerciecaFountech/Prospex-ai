using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class DnaAveragesDTO
    {
        public DnaAveragesDTO(string prospexId, List<AttributeAverages> averages)
        {
            ProspexId = prospexId;
            Averages = averages;
        }

        public string ProspexId { get; }
        public List<AttributeAverages> Averages { get; }
    }

    public class AttributeAverages
    {
        public AttributeAverages(string attributeValue, double weight, double confidence)
        {
            AttributeValue = attributeValue;
            Weight = weight;
            Confidence = confidence;
        }

        public string AttributeValue { get; }
        public double Weight { get; }
        public double Confidence { get; }
    }

}
