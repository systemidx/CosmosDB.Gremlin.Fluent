namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FlatMapFunction
    {
        public static GremlinQueryBuilder FlatMap(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"flatMap({inner.Query})");
        }
    }
}
