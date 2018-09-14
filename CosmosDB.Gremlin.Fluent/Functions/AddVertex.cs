namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddVertexFunction
    {
        public static GremlinQueryBuilder AddVertex(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"addV({parameter.Value})");
        }
    }
}
