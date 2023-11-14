using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class AttributeEntity : Entity
    {
        public Prop<VertexLabel> Label { get; set; }
        private Prop<string> _value = new Prop<string>();

        public AttributeEntity(string value)
        {
            Label = VertexLabel.Attribute;
            Value = value;
        }

        /// <summary>
        /// Value/name of the attribute.
        /// </summary>
        public Prop<string> Value
        {
            get => _value;
            set
            {
                _value = value?.ToString().ToLowerInvariant();
                SetId(_value);
            }
        }

        /// <summary>
        /// Global Weight of the attribute.
        /// </summary>
        public Prop<double> Weight { get; set; }

        /// <summary>
        /// This can be a variety of different values including if the data is active, training, levels, etc.
        /// </summary>
        public Prop<string> Status { get; set; }

        /// <summary>
        /// This is very important. Data obtained from the public domain (no login required) is generally public and data that
        /// was obtained from a private source(a client’s CRM system, email or LinkedIn account) that is not available in the
        /// public domain should be labelled “private” and never decrypted or displayed to anyone in the ProspeX™ ecosystem.
        /// </summary>
        public Prop<bool> IsPrivate { get; set; }


        /// <summary>
        /// Determines whether or not the information is good to show in ProspeX as a prospect on the "lead" cards. 
        /// Certain information, such as sanitized data and private data, are not displayable.
        /// </summary>
        public Prop<bool> IsDisplayable { get; set; }

        //public bool IsGroupable { get; set; }

        /// <summary>
        /// Determines whether or not the information can be inserted in a Recommendations Engine (RE) job. Some information,
        /// such as structured data, is not applicable to the RE.
        /// </summary>
        public Prop<bool> InCatalogue { get; set; }
        
        public string InfoBoxJson { get; set; }
        public string Description { get; set; }
    }
}