using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InFunction
    {
        /// <summary>
        /// Move to the incoming adjacent vertices given the edge labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="edgeLabels"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder In(this GremlinQueryBuilder builder, params IGremlinParameter[] edgeLabels)
        {
            if (edgeLabels == null || !edgeLabels.Any())
            {
                return builder.Add("in()");
            }
            else
            {
                if (!edgeLabels.All(l => l.TrueValue is string))
                    throw new GremlinQueryBuilderException(
                        $"{nameof(In)} only supports {nameof(edgeLabels)} that resolve to strings");
                
                builder.AddArguments(edgeLabels.OfType<GremlinArgument>().ToArray());
                return builder.Add($"in({edgeLabels.Expand()})");
            }
        }
    }
}
