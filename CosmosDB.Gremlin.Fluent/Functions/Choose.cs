namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ChooseFunction
    {
        public static GremlinQueryBuilder Choose(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            return builder.Add($"choose({functions.Expand()})");
        }
    }
}
