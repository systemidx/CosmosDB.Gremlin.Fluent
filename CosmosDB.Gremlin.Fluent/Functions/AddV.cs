namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddVFunction
    {
        public static GremlinQueryBuilder AddV(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"addV({parameter.Value})");
        }
    }
}
