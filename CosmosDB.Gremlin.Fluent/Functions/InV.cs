namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InVFunction
    {
        public static GremlinQueryBuilder InV(this GremlinQueryBuilder builder)
        {
            return builder.Add("inV()");
        }
    }
}
