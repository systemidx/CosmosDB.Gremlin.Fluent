namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InFunction
    {
        public static GremlinQueryBuilder In(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"in({parameters.Expand()})");
        }
    }
}
