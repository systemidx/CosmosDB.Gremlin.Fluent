namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddEFunction
    {
        public static GremlinQueryBuilder AddE(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"addE({parameter.Value})");
        }
    }
}
