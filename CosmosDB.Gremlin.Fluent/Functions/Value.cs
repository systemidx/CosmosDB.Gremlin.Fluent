namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ValueFunction
    {
        public static GremlinQueryBuilder Value(this GremlinQueryBuilder builder)
        {
            return builder.Add("value()");
        }
    }
}