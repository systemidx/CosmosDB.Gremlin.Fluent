namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NeqFunction
    {
        public static GremlinQueryBuilder Neq(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            return builder.Add($"neq({inner.Query})");
        }

        public static GremlinQueryBuilder Neq(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Add($"neq({parameter.Value})");
        }
    }
}
