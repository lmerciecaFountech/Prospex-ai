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
    public class PersonVertexResolutionStrategy : IVertexResolutionStrategy
    {
        private string _id;
        private string _name;
        private string _prospexId;
        private string _lomiId;
        private string _email;
        private string _sourceId;
        private Source _source;
        private List<string> _phones = new List<string>();
        private string _geolocation;
        private string _locationName;
        private string _currentCompany;

        public static PersonVertexResolutionStrategy For(Person person)
        {
            return new PersonVertexResolutionStrategy
            {
                _prospexId = person.ProspexId,
                _id = person.Id,
                _email = person.Email,
                _name = person.FullName,
                //_geolocation = person.GeoLocation,
                //_locationName = person.LocationName,
                //_currentCompany = person.CurrentCompany,
                //_phones = person.PrimaryPhone.GetAll().Concat(person.MobilePhone.GetAll()).Concat(person.Phone.GetAll()).Distinct().ToList()
            };
        }

        public static PersonVertexResolutionStrategy ForId(string id)
        {
            //Preconditions.CheckNotBlank(id, nameof(id));
            return new PersonVertexResolutionStrategy { _id = id };
        }

        public static PersonVertexResolutionStrategy ForProspexId(string prospexId)
        {
            //Preconditions.CheckNotBlank(prospexId, nameof(prospexId));
            return new PersonVertexResolutionStrategy { _prospexId = prospexId };
        }

        public static PersonVertexResolutionStrategy ForLomiId(string lomiId)
        {
            //Preconditions.CheckNotBlank(prospexId, nameof(prospexId));
            return new PersonVertexResolutionStrategy { _lomiId = lomiId };
        }

        public static PersonVertexResolutionStrategy ForEmail(string email)
        {
            //Preconditions.CheckNotBlank(email, nameof(email));
            return new PersonVertexResolutionStrategy { _email = email };
        }

        public Maybe<GraphQuery> GetQuery()
        {
            List<GraphQuery> expressions = new List<GraphQuery>();
            var query = new GraphQuery().V(VertexLabel.Person);
            if (!string.IsNullOrWhiteSpace(_id))
            {
                expressions.Add(new Expression().Has(nameof(Vertex.Id).ToLower(), _id));
            }
            else if (!string.IsNullOrWhiteSpace(_prospexId))
            {
                expressions.Add(new Expression().Has(nameof(Person.ProspexId), _prospexId));
            }
            else if (!string.IsNullOrWhiteSpace(_lomiId))
            {
                expressions.Add(new Expression().Has(nameof(Person.LomiId), _lomiId));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(_sourceId) && _source != null)
                {
                    expressions.Add(new Expression().Has(nameof(Person.SourceId), _sourceId)
                        .And(new Expression()
                            .Properties(nameof(Person.SourceId))
                            .HasValue(_sourceId)
                            .Has(nameof(Source), _source.ToString())));
                }
                if (!string.IsNullOrWhiteSpace(_email))
                {
                    expressions.Add(new Expression().Has(nameof(Person.Email), _email));
                }
                if (_phones?.Any() ?? false)
                {
                    var orExpressions = new List<GraphQuery>();
                    foreach (var phone in _phones)
                    {
                        orExpressions.Add(new Expression().Has(nameof(Person.Phone), phone));
                        orExpressions.Add(new Expression().Has(nameof(Person.PrimaryPhone), phone));
                        orExpressions.Add(new Expression().Has(nameof(Person.MobilePhone), phone));
                    }
                    expressions.Add(new Expression().Where(new Expression().Or(orExpressions.ToArray())));
                }
                if (!string.IsNullOrEmpty(_name) && !string.IsNullOrWhiteSpace(_currentCompany))
                {
                    if (!string.IsNullOrWhiteSpace(_geolocation))
                    {
                        var e = new List<GraphQuery>
                    {
                        new Expression().Has(nameof(Person.FullName), _name),
                        new Expression().Has(nameof(Person.GeoLocation), _geolocation),
                        new Expression().Has(nameof(Person.CurrentCompany), _currentCompany)
                    };

                        expressions.Add(new Expression().And(e.ToArray()));
                    }
                    else if (!string.IsNullOrWhiteSpace(_locationName))
                    {
                        var e = new List<GraphQuery>
                    {
                       new Expression().Has(nameof(Person.FullName), _name),
                       new Expression().Has(nameof(Person.LocationName), _locationName),
                       new Expression().Has(nameof(Person.CurrentCompany), _currentCompany)
                    };
                        expressions.Add(new Expression().And(e.ToArray()));
                    }
                }
            }
            return expressions.Any() 
                ? Maybe.Some(query.Or(expressions.ToArray())) 
                : Maybe<GraphQuery>.None;
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
                var possibleVertex = await gremlin.AddOrUpdateVertexAsync(this, VertexLabel.Person, entity);
                return possibleVertex.Value;
            };
        }
    }
}