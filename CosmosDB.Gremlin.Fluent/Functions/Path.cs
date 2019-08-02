namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class PathFunction
    {
        public static GremlinQueryBuilder Path(this GremlinQueryBuilder builder)
        {
            return builder.Add("path()");
        }
    }
}