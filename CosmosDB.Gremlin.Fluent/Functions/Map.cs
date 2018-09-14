namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class MapFunction
    {
        public static GremlinQueryBuilder Map(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            return builder.Add($"map({inner.Query})");
        }
    }
}
