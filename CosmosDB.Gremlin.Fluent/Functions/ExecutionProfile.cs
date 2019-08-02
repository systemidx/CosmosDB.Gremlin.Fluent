namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ExecutionProfileFunction
    {
        public static GremlinQueryBuilder ExecutionProfile(this GremlinQueryBuilder builder)
        {
            return builder.Add("executionProfile()");
        }
    }
}