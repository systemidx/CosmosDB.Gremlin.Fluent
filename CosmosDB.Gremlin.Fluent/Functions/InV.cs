namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InVFunction
    {
        /// <summary>
        /// Move to the incoming vertex
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder InV(this GremlinQueryBuilder builder)
        {
            return builder.Add("inV()");
        }
    }
}
