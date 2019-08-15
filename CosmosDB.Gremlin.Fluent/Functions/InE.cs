using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class InEFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Move to the incoming incident edges given the edge labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="edgeLabels"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder InE(this GremlinQueryBuilder builder, params IGremlinParameter[] edgeLabels)
        {
            if (edgeLabels == null || !edgeLabels.Any())
            {
                return builder.Add("inE()");
            }
            else
            {
                if (!edgeLabels.All(l => l.TrueValue is string))
                    throw new GremlinQueryBuilderException(
                        $"{nameof(InE)} only supports {nameof(edgeLabels)} that resolve to strings");
                
                builder.AddArguments(edgeLabels.OfType<GremlinArgument>().ToArray());
                return builder.Add($"inE({edgeLabels.Expand()})");
            }
        }
    }
}
