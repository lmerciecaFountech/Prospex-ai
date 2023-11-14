using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase()
        {
            
        }

        public async Task<BaseEdge> AddOrUpdateEdgeAsync(string fromId, string toId, Edge edge)
        {
            using (var gremlinEngine = GremlinEngine.GetInstance())
            {
                return await gremlinEngine.AddOrUpdateEdgeAsync(fromId, toId, edge);
            }
        }
    }
}