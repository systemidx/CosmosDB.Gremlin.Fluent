namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class RepeatFunction
    {
        public static GremlinQueryBuilder Repeat(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"repeat({inner.Query})");
        }
    }
}