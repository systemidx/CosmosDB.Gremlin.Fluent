namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BothVFunction
    {
        public static GremlinQueryBuilder BothV(this GremlinQueryBuilder builder)
        {
            return builder.Add("bothV()");
        }
    }
}
