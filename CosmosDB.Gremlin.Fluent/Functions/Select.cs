namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class SelectFunction
    {
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"select({parameters.Expand()})");
        }
    }
}
