namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class WhereFunction
    {
        public static GremlinQueryBuilder Where(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            return builder.Add($"where({functions.Expand()})");
        }
    }
}
