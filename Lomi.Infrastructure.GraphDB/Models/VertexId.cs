using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Models
{
    public class VertexId
    {
        private string id;

        public VertexId(string id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return id;
        }
    }
}