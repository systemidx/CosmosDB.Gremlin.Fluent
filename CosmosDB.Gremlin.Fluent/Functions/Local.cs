namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class LocalFunction
    {
        public static GremlinQueryBuilder Local(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"local({inner.Query})");
        }
    }
}