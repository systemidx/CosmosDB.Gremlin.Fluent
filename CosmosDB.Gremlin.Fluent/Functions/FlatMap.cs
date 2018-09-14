namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FlatMapFunction
    {
        public static GremlinQueryBuilder FlatMap(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            return builder.Add($"flatMap({inner.Query})");
        }
    }
}
