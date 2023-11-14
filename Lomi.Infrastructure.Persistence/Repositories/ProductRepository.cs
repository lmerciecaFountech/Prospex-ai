using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.GraphDB.Strategies;
using Lomi.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public async Task<Vertex> AddOrUpdateAsync(Product product, Source source)
        {
            using(var gremlinEngine = GremlinEngine.GetInstance())
            {
                var strategy = ProductVertexResolutionStrategy.For(product, source);

                var vertex = await strategy.AddOrUpdateAsync(product);

                return vertex;
            }
        }
    }
}