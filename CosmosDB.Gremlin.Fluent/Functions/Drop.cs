namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class DropFunction
    {
        public static GremlinQueryBuilder Drop(this GremlinQueryBuilder builder)
        {
            return builder.Add("drop()");
        }
    }
}
