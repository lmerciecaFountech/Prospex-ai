using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB
{
    public class GremlinEngineOld
    {
        //public async Task<Vertex> ExecuteAsync(AddVertexCommand command)
        //{
        //    return await AddVertexAsync(command);
        //}

        //public async Task<Vertex> AddVertexAsync(VertexLabel label, Entity entity)
        //{
        //    var command = new Commands.GraphCommand().AddV(label);
        //    command.Property(nameof(Vertex.CreatedAt), Today.Ticks.ToString());
        //    command.Property(nameof(Vertex.UpdatedAt), Today.Ticks.ToString());

        //    //foreach (var prop in entity.GetProperties())
        //    //{
        //    //    command.Property(prop.Key, prop.Value);
        //    //}

        //    Vertex sourceVertex = await AddVertexAsync(command);
        //    return sourceVertex;
        //}

        //public async Task<Vertex> AddVertexAsync(AddVertexCommand command)
        //{
        //    var queryText = command.BuildExpression();
        //    IDocumentQuery<dynamic> query = _client.CreateGremlinQuery<dynamic>(_graph, queryText);
        //    Vertex vertex = null;

        //    while (query.HasMoreResults)
        //    {
        //        foreach (dynamic result in await query.ExecuteNextAsync())
        //        {
        //            var resJson = JsonConvert.SerializeObject(result);
        //            vertex = JsonConvert.DeserializeObject<Vertex>(resJson);
        //        }
        //    }

        //    return vertex;
        //}

        //public async Task<Maybe<Vertex>> GetVertexAsync(GraphQuery query)
        //{
        //    var result = (await ExecuteQueryFirstAsync<Vertex>(query)).Value;
        //    return result != null ? Maybe<Vertex>.Some(result) : Maybe<Vertex>.None;
        //}

        //public async Task<Vertex> GetVertexAsync(VertexLabel label, Entity entity, string value, Source source = null)
        //{
        //    var vertex = await GetVertexAsync(new GraphQuery().V(label).Has("Value", value.EscapeSinqleQuotes()));
        //    return vertex.HasValue ? vertex.Value
        //        : null;
        //}

        //public async Task<Vertex> GetOrAddVertexAsync(VertexLabel label, Entity entity, string value, Source source = null)
        //{
        //    Maybe<Vertex> vertex = await GetVertexAsync(new GraphQuery().V(label).Has("Value", value.EscapeSinqleQuotes()));
        //    return vertex.HasValue ? vertex.Value : await AddVertexAsync(label, entity);
        //}

        //public async Task UpdateVertexValuesAsync(Vertex vertex, Dictionary<string,string> values)
        //{
        //    var query = new GraphQuery()
        //           .V(vertex.GetLabel(), vertex.GetId())
        //           .Property(values, false);

        //    await ExecuteQueryAsync(query);
        //}

        //public async Task UpdateVertexValueAsync(Vertex vertex, string key, string value)
        //{
        //    await UpdateVertexValuesAsync(vertex, new Dictionary<string, string> { { key, value } });
        //}

        //public async Task UpdateVertexPropertiesAsync(VertexLabel label, VertexId id, Entity entity)
        //{
        //    var query = new GraphQuery().V(label, id);
        //    query.Property(nameof(Vertex.UpdatedAt), Today.Ticks.ToString());

        //    foreach (var prop in entity.GetProperties())
        //    {
        //        //query = query.Property(prop.Key, prop.Value);
        //    }

        //    await ExecuteQueryAsync(query);
        //}

        //public async Task ExecuteAsync(AddEdgeCommand command)
        //{
        //    await AddEdgeAsync(command);
        //}

        //public async Task AddEdgeAsync(Edge edge, Vertex fromVertex, Vertex toVertex)
        //{
        //    if (!await EdgeExistsAsync(fromVertex, toVertex, edge.Label))
        //    {
        //        var edgeCommand = new Commands.GraphCommand().AddE(fromVertex, toVertex, edge);

        //        await AddEdgeAsync(edgeCommand);
        //    }
        //    //else
        //    //{
        //    //    await UpdateEdgeValuesAsync(fromVertex, toVertex, edge.Label, edge.GetAllProperties());
        //    //}
        //}

        //public async Task<BaseEdge> AddEdgeAsync(AddEdgeCommand command)
        //{
        //    var queryText = command.BuildExpression();
        //    IDocumentQuery<BaseEdge> query = _client.CreateGremlinQuery<BaseEdge>(_graph, queryText);

        //    while (query.HasMoreResults)
        //    {
        //        var edgeResponse = await query.ExecuteNextAsync<BaseEdge>();

        //        return edgeResponse.FirstOrDefault();
        //    }

        //    return null;
        //}

        //public async Task<BaseEdge> AddOrUpdateAttributeEdgeAsync(Vertex fromVertex, Vertex toVertex, AttributeEdge edge)
        //{
        //    if (!await AttributeEdgeExistsAsync(fromVertex, toVertex, edge))
        //    {
        //        var edgeCommand = new GraphCommand().AddE(fromVertex, toVertex, edge);

        //        return await AddEdgeAsync(edgeCommand);
        //    }
        //    //else
        //    //{
        //    //    return await UpdateEdgeValuesAsync(fromVertex, toVertex, edge.Label, edge.GetAllProperties());
        //    //}
        //}

        //public async Task UpdateEdgeValueAsync(Vertex from, Vertex to, EdgeLabel edgeLabel, string key, string value)
        //{
        //    await UpdateEdgeValuesAsync(from, to, edgeLabel, new Dictionary<string, string> { { key, value } });
        //}

        //public async Task<bool> EdgeExistsAsync(Vertex from, Vertex to, EdgeLabel edgeLabel)
        //{
        //    var query = new GraphQuery().V(from.GetLabel(), from.GetId()).Out(edgeLabel.Value).WithId(to.GetId());
        //    return await ExistsAsync(query);
        //}

        //public async Task<bool> ExistsAsync(GraphQuery graphQuery)
        //{
        //    var result = (await ExecuteQueryFirstAsync<Vertex>(graphQuery)).Value;

        //    return result != null;
        //}

        //public async Task<bool> AttributeEdgeExistsAsync(Vertex from, Vertex to, AttributeEdge edge)
        //{
        //    var query = new GraphQuery().V(from.GetLabel(), from.GetId()).Out(edge.Label.Value).WithId(to.GetId());
        //    return await ExistsAsync(query);
        //}

        //public async Task AddAttributeIfNotExistsAsync(Vertex fromVertex, Vertex toVertex, AttributeEdge edge)
        //{
        //    if (!await AttributeEdgeExistsAsync(fromVertex, toVertex, edge))
        //    {
        //        var edgeCommand = new GraphCommand().AddE(fromVertex, toVertex, edge);

        //        await AddEdgeAsync(edgeCommand);
        //    }
        //}

        //public async Task<bool> AttributeEdgeExistsAsync(VertexLabel fromLabel, VertexId fromId, VertexId toId, EdgeLabel edgeLabel, Source source)
        //{
        //    var query = new GraphQuery().V(fromLabel, fromId).OutE(edgeLabel).Has(nameof(AttributeEdge.Source), source.ToString()).InV(VertexLabel.Attribute).WithId(toId);
        //    return await ExistsAsync(query);
        //}
    }
}
