namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CoinFunction
    {
        public static GremlinQueryBuilder Coin(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            if (parameter == null)
                throw new GremlinParameterException();

            return builder.Add($"coin({parameter.Value})");
        }
    }
}
