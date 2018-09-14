namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CoalesceFunction
    {
        public static GremlinQueryBuilder Coalesce(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            return builder.Add($"coalesce({functions.Expand()})");
        }
    }
}
