namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasFunction
    {
        public static GremlinQueryBuilder Has(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"has({parameters.Expand()})");
        }
    }
}
