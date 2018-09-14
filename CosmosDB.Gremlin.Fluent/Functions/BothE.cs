namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BothEFunction
    {
        public static GremlinQueryBuilder BothE(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"bothE({parameters.Expand()})");
        }
    }
}
