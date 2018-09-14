namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BranchFunction
    {
        public static GremlinQueryBuilder Branch(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            return builder.Add($"branch({inner.Query})");
        }
    }
}
