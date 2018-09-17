namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ToFunction
    {
        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"to({parameter.Value})");
        }

        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new GremlinParameterException();

            return builder.Add($"to({func.Query})");
        }
    }
}
