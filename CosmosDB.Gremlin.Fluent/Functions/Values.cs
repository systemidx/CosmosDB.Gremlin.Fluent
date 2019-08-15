using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ValuesFunction
    {
        /// <summary>
        /// The values()-step (map) extracts the values of properties from an Element in the traversal stream
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters">Property keys to extract. Can be null or empty to get all</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Values(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder.Add($"values()");

            if (!parameters.All(p => p.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(Values)} only supports string arguments");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"values({parameters.Expand()})");
        }
    }
}