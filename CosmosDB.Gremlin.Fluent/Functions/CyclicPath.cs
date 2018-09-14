namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CyclicPathFunction
    {
        public static GremlinQueryBuilder CyclicPath(this GremlinQueryBuilder builder)
        {
            return builder.Add("cyclicPath()");
        }
    }
}
