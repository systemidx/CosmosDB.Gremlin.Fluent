namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddEdgeFunction
    {
        public static GremlinQueryBuilder AddEdge(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"addE({parameter.Value})");
        }
    }
}
