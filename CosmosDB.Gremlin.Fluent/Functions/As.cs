namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AsFunction
    {
        public static GremlinQueryBuilder As(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"as({parameter.Value})");
        }
    }
}
