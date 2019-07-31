namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class MapFunction
    {
        public static GremlinQueryBuilder Map(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"map({inner.Query})");
        }
    }
}
