namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FoldFunction
    {
        public static GremlinQueryBuilder Fold(this GremlinQueryBuilder builder)
        {
            return builder.Add("fold()");
        }
    }
}
