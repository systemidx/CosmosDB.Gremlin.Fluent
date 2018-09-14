namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ByFunction
    {
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"by({parameter.Value})");
        }

        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new GremlinParameterException();

            return builder.Add($"by({func.Query})");
        }
    }
}
