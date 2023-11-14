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
    public class ProductVertexResolutionStrategy : IVertexResolutionStrategy
    {
        #region Members

        private Source _source;
        private string _sourceId;
        private string _prospexId;
        private string _id;

        #endregion

        public static ProductVertexResolutionStrategy For(Product product, Source source)
        {
            return new ProductVertexResolutionStrategy
            {
                _id = product.Id,
                _source = source,
                _sourceId = product.SourceId
            };
        }

        public static ProductVertexResolutionStrategy For(string prospexId)
        {
            return new ProductVertexResolutionStrategy
            {
                _prospexId = prospexId,
            };
        }

        public async Task<Vertex> AddOrUpdateAsync(Entity entity)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var possibleVertex = await gremlin.AddOrUpdateVertexAsync(this, VertexLabel.Product, entity);
                return possibleVertex.Value;
            }
        }

        public async Task<Maybe<Vertex>> GetAsync()
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var graphQuery = GetQuery();

                return graphQuery.HasValue
                    ? Maybe.Some((await gremlin.ExecuteQueryFirstAsync<Vertex>(graphQuery.Value)).Value)
                    : Maybe<Vertex>.None;
            }
        }

        public Maybe<GraphQuery> GetQuery()
        {
            var query = new GraphQuery().V(VertexLabel.Product);

            var expressions = new List<GraphQuery>();

            if (!string.IsNullOrWhiteSpace(_id))
            {
                expressions.Add(new Expression().HasId(_id));
            }
            else if (!string.IsNullOrWhiteSpace(_sourceId) && _source != null)
            {
                expressions.Add(new Expression().Has(nameof(Product.SourceId), _sourceId)
                    .And(new Expression()
                        .Properties(nameof(Product.SourceId))
                        .HasValue(_sourceId)
                        .Has(nameof(Source), _source.ToString())));
            }

            return expressions.Any() 
                ? Maybe.Some(query.Expression(expressions)) 
                : Maybe<GraphQuery>.None;
        }
    }
}