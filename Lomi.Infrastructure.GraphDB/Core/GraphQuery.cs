using Lomi.Infrastructure.GraphDB.Extensions;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Core
{
    public class GraphQuery
    {
        #region Members

        protected StringBuilder _builder;

        #endregion

        #region Constructor

        public GraphQuery()
        {
            _builder = new StringBuilder("g");
        }

        #endregion

        #region Methods

        public GraphQuery G()
        {
            _builder.Append("g");

            return this;
        }

        public GraphQuery V()
        {
            _builder.Append(".V()");

            return this;
        }

        public GraphQuery V(VertexLabel label)
        {
            _builder.Append($".V().hasLabel('{label.ToString()?.EscapeData()}')");

            return this;
        }

        public GraphQuery V(Vertex vertex)
        {
            return V(vertex.GetLabel(), vertex.GetId());
        }

        public GraphQuery V(VertexLabel label, VertexId id)
        {
            return V().HasLabel(label).WithId(id);
        }

        public GraphQuery E()
        {
            _builder.Append(".E()");

            return this;
        }

        public GraphQuery HasValue(string value)
        {
            _builder.Append($".hasValue('{value?.EscapeData()}')");
            return this;
        }

        public GraphQuery HasLabel(VertexLabel label)
        {
            _builder.Append($".hasLabel('{label.ToString()?.EscapeData()}')");
            return this;
        }

        public GraphQuery HasLabel(EdgeLabel label)
        {
            _builder.Append($".hasLabel('{label.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery HasLabel(params EdgeLabel[] edgeLabels)
        {
            string s = string.Join("','", edgeLabels.Select(x => x.Value?.EscapeData()));
            _builder.Append($".hasLabel('{s}')");
            return this;
        }

        public GraphQuery Not(GraphQuery query, string prefix = "")
        {
            _builder.Append($"{prefix}.not({query.BuildExpression()})");
            return this;
        }

        public GraphQuery Has(string propertyName, string value)
        {
            _builder.Append($".has('{propertyName}', '{value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Has(string propertyName, bool value)
        {
            return Has(propertyName, value.ToString()?.EscapeData());
        }

        public GraphQuery Has(string propertyName, GraphQuery graphQuery)
        {
            _builder.Append($".has('{propertyName}', {graphQuery.BuildExpression()})");
            return this;
        }

        public GraphQuery Has(Dictionary<string, string> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Has(pair.Key, pair.Value);
            }

            return this;
        }

        public GraphQuery HasId(string value)
        {
            _builder.Append($".hasId('{value?.EscapeData()}')");
            return this;
        }

        public GraphQuery WithId(VertexId id)
        {
            return Has("id", id.ToString());
        }

        public GraphQuery Has(string label, string propertyName, string value)
        {
            _builder.Append($".has('{label}', '{propertyName}', '{value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Mean()
        {
            _builder.Append(".mean()");
            return this;
        }

        public GraphQuery Until(GraphQuery query)
        {
            _builder.Append($".until({query.BuildExpression()})");
            return this;
        }

        public GraphQuery Repeat(GraphQuery query)
        {
            _builder.Append($".repeat({query.BuildExpression()})");
            return this;
        }

        public GraphQuery As(params string[] values)
        {
            string s = string.Join(",", values.Select(x => x.InQuotes()));
            _builder.Append($".as({s})");
            return this;
        }

        public object ValueMap(params string[] values)
        {
            string s = string.Join(",", values.Select(x => x.InQuotes()));
            _builder.Append($".valueMap({s})");
            return this;
        }

        public GraphQuery Values(params string[] values)
        {
            string s = string.Join(",", values.Select(x => x.InQuotes()));
            _builder.Append($".valueMap({s})");
            return this;
        }

        public GraphQuery Values(string name)
        {
            _builder.Append($".values('{name}')");
            return this;
        }

        public GraphQuery ValuesOrEmpty(string name)
        {
            Coalesce(new Expression().Values(name),
                new Expression().Constant(""));

            return this;
        }

        public GraphQuery ValuesOrZero(string name)
        {
            Coalesce(new Expression().Values(name),
                new Expression().Constant(0));

            return this;
        }

        public GraphQuery Out(EdgeLabel edgeLabel)
        {
            _builder.Append($".out('{edgeLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Choose(GraphQuery conditionQuery, GraphQuery trueQuery, GraphQuery falseQuery)
        {
            _builder.Append($".choose({conditionQuery.BuildExpression()}, {trueQuery.BuildExpression()}, {falseQuery.BuildExpression()})");
            return this;
        }

        public GraphQuery Out(string value)
        {
            _builder.Append($".out('{value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Out()
        {
            _builder.Append($".out()");
            return this;
        }

        public GraphQuery OutE()
        {
            _builder.Append($".outE()");
            return this;
        }

        public GraphQuery OutE(EdgeLabel edgeLabel)
        {
            _builder.Append($".outE('{edgeLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery OutE(params EdgeLabel[] values)
        {
            string s = string.Join("','", values.Select(x => x.Value?.EscapeData()));
            _builder.Append($".outE('{s}')");
            return this;
        }

        public GraphQuery InE(EdgeLabel edgeLabel)
        {
            _builder.Append($".inE('{edgeLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Expression(GraphQuery query)
        {
            if (query != null)
            {
                _builder.Append($".{query.BuildExpression()}");
            }
            return this;
        }

        public GraphQuery Expression(List<GraphQuery> expressions)
        {
            foreach (var expression in expressions)
            {
                Expression(expression);
            }
            return this;
        }

        public GraphQuery InE(params EdgeLabel[] values)
        {
            string s = string.Join("','", values.Select(x => x.Value?.EscapeData()));
            _builder.Append($".inE('{s}')");
            return this;
        }

        public GraphQuery OutV(VertexLabel vertexLabel)
        {
            _builder.Append($".outV().hasLabel('{vertexLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Optional(GraphQuery query)
        {
            _builder.Append($".optional({query.BuildExpression()})");
            return this;
        }

        public GraphQuery InV(VertexLabel vertexLabel)
        {
            _builder.Append($".inV().hasLabel('{vertexLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery InV(string value)
        {
            _builder.Append($".inV('{value?.EscapeData()}')");
            return this;
        }

        public GraphQuery InV()
        {
            _builder.Append($".inV()");
            return this;
        }

        public GraphQuery Neq(string value)
        {
            _builder.Append($".where(neq('{value?.EscapeData()}'))");
            return this;
        }

        public GraphQuery Group()
        {
            _builder.Append(".group()");
            return this;
        }

        public GraphQuery GroupBy(string name)
        {
            _builder.Append($".group().by('{name}')");
            return this;
        }

        public GraphQuery GroupBy(GraphQuery graphQuery)
        {
            _builder.Append($".group().by({graphQuery})");
            return this;
        }

        public GraphQuery Raw(string query)
        {
            _builder.Append(query);
            return this;
        }

        public GraphQuery Where(GraphQuery query)
        {
            _builder.Append($".where({query.BuildExpression()})");
            return this;
        }

        public GraphQuery OrderByDecr(string value)
        {
            return OrderBy(value, "decr");
        }

        public GraphQuery OrderByIncr(string value)
        {
            return OrderBy(value, "incr");
        }

        private GraphQuery OrderBy(string value, string order)
        {
            _builder.Append($".order().by({value.InQuotes()}, {order})");
            return this;
        }

        public GraphQuery By(string name)
        {
            _builder.Append($".by('{name}')");
            return this;
        }

        public GraphQuery ByOrEmpty(string name)
        {
            By(new Expression().Coalesce(new Expression().Values(name),
                new Expression().Constant("")));

            return this;
        }

        public GraphQuery ByOrZero(string name)
        {
            By(new Expression().Coalesce(new Expression().Values(name),
                new Expression().Constant(0)));

            return this;
        }

        public GraphQuery By(GraphQuery query)
        {
            _builder.Append($".by({query.BuildExpression()})");
            return this;
        }

        public GraphQuery Property(string key, string value, bool list = false, params KeyValuePair<string, string>[] subProperties)
        {
            var joinedSubProperties = subProperties.HasValue()
                ? $", {string.Join(", ", subProperties.SelectMany(x => new[] { x.Key.InQuotes(), x.Value.InQuotes() }))}"
                : "";

            _builder.Append(list
                ? $".property(list, '{key}', '{value.EscapeSinqleQuotes().EscapeData()}'{joinedSubProperties})"
                : $".property('{key}', '{value.EscapeSinqleQuotes().EscapeData()}'{joinedSubProperties})");

            return this;
        }

        public GraphQuery Property(Dictionary<string, string> properties, bool list = false)
        {
            foreach (var property in properties)
            {
                Property(property.Key, property.Value, list);
            }
            return this;
        }

        public GraphQuery Properties(string key)
        {
            _builder.Append($".properties('{key}')");
            return this;
        }

        public GraphQuery Drop()
        {
            _builder.Append($".drop()");
            return this;
        }

        public GraphQuery Select(params string[] values)
        {
            string s = string.Join(",", values.Select(x => x.InQuotes()));
            _builder.Append($".select({s})");

            return this;
        }

        public GraphQuery ByLabel()
        {
            _builder.Append($".by('label')");
            return this;
        }

        public GraphQuery By()
        {
            _builder.Append($".by()");
            return this;
        }

        public GraphQuery Dedup()
        {
            _builder.Append(".dedup()");
            return this;
        }

        public GraphQuery Limit(int count)
        {
            _builder.Append($".limit({count})");
            return this;
        }

        public GraphQuery Shuffle()
        {
            _builder.Append($".order().by(shuffle)");
            return this;
        }

        public GraphQuery Coin(double step)
        {
            _builder.Append($".coin({step})");
            return this;
        }

        public GraphQuery Project(params string[] values)
        {
            string s = string.Join(",", values.Select(x => x.InQuotes()));
            _builder.Append($".project({s})");

            return this;
        }

        public GraphQuery GroupCount()
        {
            _builder.Append($".groupCount()");
            return this;
        }

        public GraphQuery Is(string name)
        {
            _builder.Append($".is('{name?.EscapeData()}')");
            return this;
        }

        public GraphQuery Is(int value)
        {
            _builder.Append($".is('{value}')");
            return this;
        }

        public GraphQuery Is(GraphQuery query)
        {
            _builder.Append($".is({query.BuildExpression()})");
            return this;
        }

        public GraphQuery Lt(double value)
        {
            _builder.Append($"lt({value.ToString()})");
            return this;
        }

        public GraphQuery Lt(long value)
        {
            _builder.Append($"lt({value.ToString()})");
            return this;
        }

        public GraphQuery LessThan(string propertyName, long value)
        {
            _builder.Append($".values('{propertyName}').is(lt({value}))");
            return this;
        }

        public GraphQuery Gt(double value)
        {
            _builder.Append($"gt({value.ToString()})");
            return this;
        }

        public GraphQuery Gt(long value)
        {
            _builder.Append($"gt({value.ToString()})");
            return this;
        }

        public GraphQuery Count()
        {
            _builder.Append($".count()");

            return this;
        }

        public GraphQuery Between(double min, double max)
        {
            _builder.Append($".between('{min}', '{max}')");

            return this;
        }

        public GraphQuery AddE(EdgeLabel edgeLabel)
        {
            _builder.Append($".addE('{edgeLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery AddV(VertexLabel vertexLabel)
        {
            _builder.Append($".addV('{vertexLabel.Value?.EscapeData()}')");
            return this;
        }

        public GraphQuery Union(params GraphQuery[] graphQueries)
        {
            string s = string.Join(",", graphQueries.Select(x => x.BuildExpression()));
            _builder.Append($".union({s})");
            return this;
        }

        public GraphQuery Or(params GraphQuery[] graphQueries)
        {
            string s = string.Join(",", graphQueries.Select(x => x.BuildExpression()));
            _builder.Append($".or({s})");
            return this;
        }

        public GraphQuery And(params GraphQuery[] queries)
        {
            var queriesList = queries.Where(x => x != null);

            if (queriesList.Any())
            {
                string s = string.Join(",", queriesList.Select(x => x.BuildExpression()).Where(x => !string.IsNullOrWhiteSpace(x)));

                _builder.Append($".and({s})");
            }

            return this;
        }

        public GraphQuery By(GremlinExpression expr)
        {
            _builder.Append($".by({expr})");
            return this;
        }

        public GraphQuery GroupBy(GremlinExpression expr)
        {
            _builder.Append($".group().by({expr})");
            return this;
        }

        public GraphQuery Constant(bool value)
        {
            _builder.Append($".constant({value.ToString().ToLower()})");
            return this;
        }

        public GraphQuery Constant(double value)
        {
            _builder.Append($".constant({value.ToString().ToLower()})");
            return this;
        }

        public GraphQuery Constant(int value)
        {
            _builder.Append($".constant({value.ToString().ToLower()})");
            return this;
        }

        public GraphQuery Constant(string value)
        {
            _builder.Append($".constant('{(value?.EscapeData() ?? "").ToLower()}')");
            return this;
        }

        public GraphQuery Eq(string value)
        {
            _builder.Append($".eq('{value.EscapeSinqleQuotes().EscapeData()}')");
            return this;
        }

        public GraphQuery Eq(long value)
        {
            _builder.Append($".eq({value})");
            return this;
        }

        public GraphQuery Order()
        {
            _builder.Append(".order()");
            return this;
        }

        public GraphQuery Coalesce(GraphQuery trueQuery, GraphQuery falseQuery)
        {
            _builder.Append($".coalesce({trueQuery.BuildExpression()}, {falseQuery.BuildExpression()})");
            return this;
        }

        public GraphQuery Fold()
        {
            _builder.Append(".fold()");
            return this;
        }

        public GraphQuery Unfold()
        {
            _builder.Append(".unfold()");
            return this;
        }

        public GraphQuery From(string name)
        {
            _builder.Append($".from({name.InQuotes()})");
            return this;
        }

        internal GraphQuery From(GraphQuery graphQuery)
        {
            _builder.Append($".from({graphQuery.BuildExpression()})");
            return this;
        }

        public GraphQuery To(string name)
        {
            _builder.Append($".to({name.InQuotes()})");
            return this;
        }

        internal GraphQuery To(GraphQuery graphQuery)
        {
            _builder.Append($".to({graphQuery.BuildExpression()})");
            return this;
        }

        public GraphQuery Break()
        {
            _builder.Append(";");
            return this;
        }

        public string BuildExpression()
        {
            return _builder.ToString().TrimStart('.');
        }

        #endregion
    }

    public class Expression : GraphQuery
    {
        public Expression()
        {
            _builder = new StringBuilder();
        }
    }

    public class GremlinExpression
    {
        public GremlinExpression(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
