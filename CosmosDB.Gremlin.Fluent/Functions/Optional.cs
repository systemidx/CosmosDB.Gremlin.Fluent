namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OptionalFunction
    {
        public static GremlinQueryBuilder Optional(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"optional({inner.Query})");
        }
    }
}