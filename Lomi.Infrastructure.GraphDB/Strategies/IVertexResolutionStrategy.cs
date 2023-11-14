using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Strategies
{
    public interface IVertexResolutionStrategy
    {
        Maybe<GraphQuery> GetQuery();
        Task<Maybe<Vertex>> GetAsync();
        Task<Vertex> AddOrUpdateAsync(Entity entity);
    }
}