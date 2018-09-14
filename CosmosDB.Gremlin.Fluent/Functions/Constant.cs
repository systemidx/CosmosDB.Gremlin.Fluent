namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ConstantFunction
    {
        public static GremlinQueryBuilder Constant(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"constant({parameter.Value})");
        }
    }
}
