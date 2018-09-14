namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OutVFunction
    {
        public static GremlinQueryBuilder OutV(this GremlinQueryBuilder builder)
        {
            return builder.Add("outV()");
        }
    }
}
