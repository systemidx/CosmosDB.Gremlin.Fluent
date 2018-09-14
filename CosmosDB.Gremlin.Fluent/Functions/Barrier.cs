namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BarrierFunction
    {
        public static GremlinQueryBuilder Barrier(this GremlinQueryBuilder builder)
        {
            return builder.Add("barrier()");
        }
    }
}
