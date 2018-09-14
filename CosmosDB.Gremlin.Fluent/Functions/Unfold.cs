namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class UnfoldFunction
    {
        public static GremlinQueryBuilder Unfold(this GremlinQueryBuilder builder)
        {
            return builder.Add("unfold()");
        }
    }
}
