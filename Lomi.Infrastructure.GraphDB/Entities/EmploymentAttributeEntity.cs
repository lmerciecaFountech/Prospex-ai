using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class EmploymentAttributeEntity : AttributeEntity
    {
        public EmploymentAttributeEntity(string value) : base(value)
        {
        }

        public override string GetEntityType()
        {
            return nameof(AttributeEntity);
        }

        public Prop<long> EmploymentFromDate { get; set; }
        public Prop<long> EmploymentToDate { get; set; }
    }
}
