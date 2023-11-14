using Lomi.Infrastructure.GraphDB.Core;
using Lomi.Infrastructure.GraphDB.Extensions;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Interfaces;
using Lomi.Infrastructure.GraphDB.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Graphs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Strategies;
using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;
using System.Configuration;

namespace Lomi.Infrastructure.GraphDB
{
    public class GremlinEngine : IDisposable
    {
        #region Members

        //private DocumentClient _client;
        //private DocumentCollection _graph;
        //private string EndPointUrl { get; set; }
        //private string AuthKey { get; set; }
        //private string DocumentCollectionId { get; set; }
        //private string DatabaseId { get; set; }
        //private int OfferThroughput { get; set; }
        private static GremlinEngine _gremlinEngine;


        private readonly GremlinClient _client;

        #endregion

        #region Constructor

        public GremlinEngine()
        {
            var database = "GraphX";
            var collection = "Prospex";
            var username = "/dbs/" + database + "/colls/" + collection;
            //var port = Convert.ToInt32(ConfigurationManager.AppSettings["GremlinPort"]);
            //var hostname = ConfigurationManager.AppSettings["GremlinHostname"];
            //var password = ConfigurationManager.AppSettings["GremlinKey"];

            var port = 443;
            var hostname = "lomienginedemo.gremlin.cosmos.azure.com";
            var password = "mJCKeBWIuBwGVJLPzSj7txyrxjelOMoDuZkWjV1yY0ESYtie5E3Uo9d46O6oUiow1mnCbjwjRCe3NP1ytgEDUw==";

            GremlinServer gremlinServer;

            if(hostname.Equals("localhost"))
                gremlinServer = new GremlinServer(hostname, port, false, username, password);
            else if (hostname.Contains("lominenginedemo"))
                gremlinServer = new GremlinServer(hostname, port, true, username, password);
            else
                gremlinServer = new GremlinServer(hostname, port, true, username, password);

            _client = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType);

            //EndPointUrl = "https://localhost:8081";
            //AuthKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            //DatabaseId = "GraphX";
            //DocumentCollectionId = "Prospex";
            //_client = new DocumentClient(new Uri(EndPointUrl), AuthKey);
            //_client.ConnectionPolicy.ConnectionMode = ConnectionMode.Direct;
            //_client.OpenAsync();
            //_graph = _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
            //    new DocumentCollection { Id = DocumentCollectionId },
            //    new RequestOptions { OfferThroughput = OfferThroughput, PartitionKey = new PartitionKey("/PartitionId") }).Result;
            //_graph.IndexingPolicy.Automatic = true;
        }

        public static GremlinEngine GetInstance()
        {
            if (_gremlinEngine == null)
            {
                _gremlinEngine = new GremlinEngine();
            }
            return _gremlinEngine;
        }

        #endregion

        #region Methods

        public async Task<Maybe<Vertex>> AddOrUpdateVertexAsync<T>(T vertexResolutionStrategy, VertexLabel label, Entity entity) where T : IVertexResolutionStrategy
        {
            var getQuery = vertexResolutionStrategy.GetQuery();

            if (!getQuery.HasValue) return Maybe<Vertex>.None;

            var graphQuery = getQuery.Value;

            graphQuery.Fold().Coalesce(new Expression().Unfold(), AddVertexExpression(label, entity));

            graphQuery.Expression(AddOrUpdateProperties(entity.GetMarkedAsDirty()));

            var vertex = await ExecuteQueryFirstAsync<Vertex>(graphQuery);

            return vertex;
        }

        public async Task<Maybe<Vertex>> UpdateVertexAsync(Entity entity)
        {
            var graphQuery = new GraphQuery().V().HasId(entity.Id)
                .Expression(AddOrUpdateProperties(entity.GetMarkedAsDirty()));

            return await ExecuteQueryFirstAsync<Vertex>(graphQuery);
        }

        public async Task<Maybe<Vertex>> GetVertexAsync(string id)
        {
            var graphQuery = new GraphQuery().V().HasId(id);

            return await ExecuteQueryFirstAsync<Vertex>(graphQuery);
        }

        public async Task<Vertex> GetVertexByPropertyAsync(VertexLabel vertexLabel, Dictionary<string, string> dictionary)
        {
            var query = new GraphQuery()
                .V(vertexLabel)
                .Has(dictionary);

            var vertex = await ExecuteQueryFirstAsync<Vertex>(query);

            return vertex.HasValue
                ? vertex.Value
                : null;
        }

        public async Task<BaseEdge> AddOrUpdateEdgeAsync(string fromId, string toId, Edge edge)
        {
            edge.SetId(fromId, toId);

            var graphQuery = new GraphQuery()
                        .E()
                        .HasId(edge.Id)
                        .Fold()
                        .Coalesce(new Expression().Unfold(),
                            AddEdgeExpression(edge.Label, edge.GetProperties())
                                .From(new GraphQuery().V().HasId(fromId))
                                .To(new GraphQuery().V().HasId(toId)))
                        .Expression(AddOrUpdateProperties(edge.GetMarkedAsDirty()));

            var baseEdge = await ExecuteQueryFirstAsync<BaseEdge>(graphQuery);
            return baseEdge.Value;
        }

        public async Task<Maybe<BaseEdge>> UpdateEdgeAsync(string fromId, string toId, Edge edge)
        {
            edge.SetId(fromId, toId);

            return await UpdateEdgeAsync(edge);
        }

        public async Task<Maybe<BaseEdge>> UpdateEdgeAsync(Edge edge)
        {
            var graphQuery = new GraphQuery()
                .E()
                .HasId(edge.Id)
                .Expression(AddOrUpdateProperties(edge.GetMarkedAsDirty()));

            return await ExecuteQueryFirstAsync<BaseEdge>(graphQuery);
        }

        public async Task<BaseEdge> GetEdgeAsync(Vertex from, Vertex to, EdgeLabel edgeLabel)
        {
            var query = new GraphQuery()
                            .V()
                            .HasLabel(from.GetLabel()).WithId(from.GetId())
                                                      .OutE(EdgeLabel.From(edgeLabel.Value)).Where(new Expression().InV(to.GetLabel()).WithId(to.GetId()));

            var baseEdge = await ExecuteQueryFirstAsync<BaseEdge>(query);
            return baseEdge.HasValue
                ? baseEdge.Value
                : null;
        }

        public async Task<BaseEdge> UpdateEdgeValuesAsync(Vertex from, Vertex to, EdgeLabel edgeLabel, Dictionary<string, string> values)
        {
            values[nameof(Edge.UpdatedAt)] = Today.Ticks.ToString();
            if (values.ContainsKey(nameof(Edge.CreatedAt)))
            {
                values.Remove(nameof(Edge.CreatedAt));
            }

            var query = new GraphQuery()
                .V(from.GetLabel(), from.GetId())
                .OutE(edgeLabel)
                .Where(new Expression()
                    .InV(to.GetLabel())
                    .WithId(to.GetId()))
                .Property(values, false);

            var baseEdgeResult = await ExecuteQueryAsync<BaseEdge>(query);

            return baseEdgeResult.FirstOrDefault();
        }

        public async Task UpdateEdgeValueAsync(string id, string key, string value)
        {
            var query = new GraphQuery()
                .E()
                .Has(nameof(id), id)
                .Property(key, value, false);

            await ExecuteQueryAsync<BaseEdge>(query);
        }

        public async Task<Maybe<T>> ExecuteQueryFirstAsync<T>(GraphQuery query, IJsonConverter<T> jsonConverter = null)
        {
            var result = await ExecuteQueryAsync(query.Limit(1), jsonConverter);
            var item = result.FirstOrDefault();
            return item == null ? Maybe<T>.None : Maybe<T>.Some(item);
        }

        public async Task<List<T>> ExecuteQueryAsync<T>(GraphQuery query, IJsonConverter<T> jsonConverter = null)
        {
            string queryText = query.BuildExpression();
            queryText = queryText.Replace("\\'", "");

            var results = new List<T>();

            try
            {
                var rs = await _client.SubmitAsync<dynamic>(queryText);
                var resJson = JsonConvert.SerializeObject(rs);
                results = JsonConvert.DeserializeObject<List<T>>(resJson);

                if (results.Count == 0)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return results;

            //IDocumentQuery<dynamic> q = _client.CreateGremlinQuery<dynamic>(_graph, queryText);
            //List<T> results = new List<T>();
            //while (q.HasMoreResults)
            //{
            //    foreach (JToken result in await q.ExecuteNextAsync())
            //    {
            //        if (jsonConverter != null)
            //        {
            //            results.Add(jsonConverter.Deserialize(result));
            //        }
            //        else
            //        {
            //            result.UnEscapeAllvalues();

            //            if (result.Type == JTokenType.String)
            //            {
            //                results.Add((T)Convert.ChangeType(result.ToString(), typeof(T)));
            //            }
            //            else
            //            {
            //                results.Add(JsonConvert.DeserializeObject<T>(result.ToString()));
            //            }
            //        }
            //    }
            //}

            //return results;
        }

        public async Task<bool> ExecuteQueryAsync(GraphQuery query)
        {
            string queryText = query.BuildExpression();

            var result = await _client.SubmitAsync<dynamic>(queryText);

            return result.Count > 0;

            //IDocumentQuery<dynamic> q = _client.CreateGremlinQuery<dynamic>(_graph, queryText);
            //var anyResult = false;
            //while (q.HasMoreResults)
            //{
            //    foreach (JToken result in await q.ExecuteNextAsync())
            //    {
            //        anyResult = true;
            //    }
            //}
            //return anyResult;
        }

        #endregion

        #region Private Methods

        private Expression AddVertexExpression(VertexLabel label, Entity entity)
        {
            var properties = entity.GetProperties();

            var expression = new Expression().AddV(label)
                .Expression(AddOrUpdateProperties(properties, false));

            return expression as Expression;
        }

        private Expression AddEdgeExpression(EdgeLabel label, Dictionary<string, List<KeyValuePair<string, string>>> properties)
        {
            var expression = new Expression().AddE(label);

            foreach (var property in properties.Where(p => p.Value.Where(pp => pp.Value != null).Any()))
            {
                var unset = property.Value.FirstOrDefault(x => x.Key == Source.Unset.Value);

                if (unset.Key == Source.Unset.Value)
                {
                    expression.Property(property.Key, unset.Value);
                }
                else
                {
                    foreach (var source in property.Value)
                    {
                        expression.Property(property.Key, source.Value, true, new KeyValuePair<string, string>(nameof(Source), source.Key));
                    }
                }
            }

            return expression as Expression;
        }

        private static Expression AddOrUpdateProperties(Dictionary<string, List<KeyValuePair<string, string>>> properties, bool skipPartitionId = true)
        {
            var expression = new Expression();

            foreach (var property in properties.Where(p => p.Value.Where(pp => pp.Value != null).Any()))
            {
                if (skipPartitionId && property.Key == nameof(Entity.PartitionId))
                {
                    continue;
                }
                var unset = property.Value.FirstOrDefault(x => x.Key == Source.Unset.Value);

                if (unset.Key == Source.Unset.Value)
                {
                    expression.Property(property.Key, unset.Value);
                }
                else
                {
                    var first = property.Value.FirstOrDefault();
                    foreach (var source in property.Value)
                    {
                        expression.Property(property.Key, source.Value, !source.Equals(first), new KeyValuePair<string, string>(nameof(Source), source.Key));
                    }
                }
            }

            return expression;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            if (_client != null)
            {
                _client?.Dispose();
            }
        }

        #endregion
    }
}