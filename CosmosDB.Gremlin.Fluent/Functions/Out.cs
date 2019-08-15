using System.Linq;
using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OutFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Move to the outgoing adjacent vertices given the edge labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="edgeLabels"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Out(this GremlinQueryBuilder builder, params IGremlinParameter[] edgeLabels)
        {
            if (edgeLabels == null || !edgeLabels.Any())
                return builder.Add($"out()");
            if (!edgeLabels.All(l => l.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Out)} only supports {nameof(edgeLabels)} that resolve to strings");

            builder.AddArguments(edgeLabels.OfType<GremlinArgument>().ToArray());
            return builder.Add($"out({edgeLabels.Expand()})");
        }
    }
}
