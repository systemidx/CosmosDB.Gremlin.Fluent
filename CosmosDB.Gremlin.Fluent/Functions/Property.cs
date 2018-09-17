namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class PropertyFunction
    {
        public static GremlinQueryBuilder Property(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"property({parameters.Expand()})");
        }
    }
}
