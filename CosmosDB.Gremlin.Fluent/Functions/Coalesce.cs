using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CoalesceFunction
    {
        public static GremlinQueryBuilder Coalesce(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"coalesce({functions.Expand()})");
        }
    }
}
