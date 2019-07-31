namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class SideEffectFunction
    {
        public static GremlinQueryBuilder SideEffect(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"sideEffect({inner.Query})");
        }
    }
}
