namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class SideEffectFunction
    {
        public static GremlinQueryBuilder SideEffect(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            return builder.Add($"sideEffect({inner.Query})");
        }
    }
}
