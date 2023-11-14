using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Dna : Entity
    {
        public Prop<VertexLabel> Label { get; set; }

        public Dna(string id)
        {
            SetId(id);
            Label = VertexLabel.DNA;
        }

        /// <summary>
        /// Dna catalog flag. 
        /// </summary>
        public bool DCF { get; set; }

        /// <summary>
        /// Last time it was processed by recommendation engine.
        /// </summary>
        public long LastRecommendationUpdateAt { get; set; }

        /// <summary>
        /// Required daily leads.
        /// </summary>
        public int RDL { get; set; }

        internal static Dictionary<string, string> GetProperties()
        {
            var dictionary = new Dictionary<string, string>();
            var properties = typeof(Dna).GetProperties();

            foreach (var property in properties.Where(x => x.PropertyType.IsPrimitive))
            {
                dictionary.Add(property.Name, Activator.CreateInstance(property.PropertyType).ToString());
            }

            return dictionary;
        }
    }
}