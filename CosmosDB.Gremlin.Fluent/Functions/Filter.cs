namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FilterFunction
    {
        public static GremlinQueryBuilder Filter(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"filter({inner.Query})");
        }
    }
}
