namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FilterFunction
    {
        public static GremlinQueryBuilder Filter(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            return builder.Add($"filter({inner.Query})");
        }
    }
}
