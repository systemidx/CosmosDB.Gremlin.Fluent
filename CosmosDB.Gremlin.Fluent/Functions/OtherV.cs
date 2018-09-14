namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OtherVFunction
    {
        public static GremlinQueryBuilder OtherV(this GremlinQueryBuilder builder)
        {
            return builder.Add("otherV()");
        }
    }
}
