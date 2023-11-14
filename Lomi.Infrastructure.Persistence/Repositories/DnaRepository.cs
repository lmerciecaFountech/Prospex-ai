using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public class DnaRepository : RepositoryBase, IDnaRepository
    {
        public async Task<Maybe<Vertex>> UpdateAsync(Dna dna)
        {
            using (var gremlinEngine = GremlinEngine.GetInstance())
            {
                return await gremlinEngine.UpdateVertexAsync(dna);
            }
        }
    }
}