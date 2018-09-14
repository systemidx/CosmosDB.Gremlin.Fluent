namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AggregateFunction
    {
        public static GremlinQueryBuilder Aggregate(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"aggregate({parameter.Value})");
        }
    }
}
