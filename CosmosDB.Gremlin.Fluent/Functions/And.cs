using System.Text;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AndFunction
    {
        public static GremlinQueryBuilder And(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            return builder.Add($"and({functions.Expand()})");
        }
    }
}
