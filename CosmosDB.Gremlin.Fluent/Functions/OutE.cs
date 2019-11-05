using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OutEFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Move to the outgoing incident edges given the edge labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="edgeLabels"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder OutE(this GremlinQueryBuilder builder, params IGremlinParameter[] edgeLabels)
        {
            if (edgeLabels == null || !edgeLabels.Any())
                return builder.Add("outE()");
            
            if (!edgeLabels.All(l => l.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(OutE)} only supports {nameof(edgeLabels)} that resolve to strings");

            builder.AddArguments(edgeLabels.OfType<GremlinArgument>().ToArray());
            return builder.Add($"outE({edgeLabels.Expand()})");
        }
    }
}
