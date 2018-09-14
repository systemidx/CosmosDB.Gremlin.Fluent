namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CountFunction
    {
        public static GremlinQueryBuilder Count(this GremlinQueryBuilder builder)
        {
            return builder.Add("count()");
        }
    }
}
