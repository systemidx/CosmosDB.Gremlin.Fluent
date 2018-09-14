namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OutEFunction
    {
        public static GremlinQueryBuilder OutE(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"outE({parameters.Expand()})");
        }
    }
}
