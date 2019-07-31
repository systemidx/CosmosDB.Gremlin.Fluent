using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class WhereFunction
    {
        public static GremlinQueryBuilder Where(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"where({functions.Expand()})");
        }
    }
}
