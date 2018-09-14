namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddPropertyFunction
    {
        public static GremlinQueryBuilder AddProperty(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"property({parameters.Expand()})");
        }
    }
}
