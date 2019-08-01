namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OrderFunction
    {
        public static GremlinQueryBuilder Order(this GremlinQueryBuilder builder)
        {
            return builder.Add("order()");
        }
    }
}