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
    public class DnaVertexResolutionStrategy : IVertexResolutionStrategy
    {
        private string _email;
        private string _prospexId;
        private string _personId;

        public static DnaVertexResolutionStrategy ForProspexId(string prospexId)
        {
            //Preconditions.CheckNotBlank(prospexId, nameof(prospexId));
            return new DnaVertexResolutionStrategy { _prospexId = prospexId };
        }

        public static DnaVertexResolutionStrategy ForPersonId(string personId)
        {
            //Preconditions.CheckNotBlank(prospexId, nameof(prospexId));
            return new DnaVertexResolutionStrategy { _personId = personId };
        }

        public static DnaVertexResolutionStrategy ForEmail(string email)
        {
            //Preconditions.CheckNotBlank(email, nameof(email));
            return new DnaVertexResolutionStrategy { _email = email };
        }

        public Maybe<GraphQuery> GetQuery()
        {
            var query = new GraphQuery().V(VertexLabel.Person);

            if (!string.IsNullOrWhiteSpace(_personId))
            {
                query = query.Has(nameof(Person.Id).ToLower(), _personId);
            }
            else if (!string.IsNullOrWhiteSpace(_prospexId))
            {
                query = query.Has(nameof(Person.ProspexId), _prospexId);
                //query = query.Has(nameof(Person.SourceId), $"{Source.Onboarding}{nameof(Person)}{_prospexId}");
            }
            else if (!string.IsNullOrWhiteSpace(_email))
            {
                query = query.Has(nameof(Person.Email), _email);
            }

            query = query.OutE(EdgeLabel.Has).InV(VertexLabel.DNA);

            return Maybe.Some(query);
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

        public async Task<Vertex> AddOrUpdateAsync(Entity entity)
        {
            using (var gremlin = GremlinEngine.GetInstance())
            {
                var possibleVertex = await gremlin.AddOrUpdateVertexAsync(this, VertexLabel.DNA, entity);
                return possibleVertex.Value;
            }
        }
    }
}