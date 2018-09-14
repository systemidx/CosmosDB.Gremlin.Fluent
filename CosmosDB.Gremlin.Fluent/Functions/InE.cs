namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InEFunction
    {
        public static GremlinQueryBuilder InE(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"inE({parameters.Expand()})");
        }
    }
}
