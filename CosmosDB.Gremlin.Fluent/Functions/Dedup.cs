namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class DedupFunction
    {
        public static GremlinQueryBuilder Dedup(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"dedup({parameters.Expand()})");
        }
    }
}
