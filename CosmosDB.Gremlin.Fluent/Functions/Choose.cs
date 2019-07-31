using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ChooseFunction
    {
        public static GremlinQueryBuilder Choose(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"choose({functions.Expand()})");
        }
    }
}
