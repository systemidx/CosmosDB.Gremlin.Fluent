namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OutVFunction
    {
        /// <summary>
        /// Move to the outgoing vertex
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder OutV(this GremlinQueryBuilder builder)
        {
            return builder.Add("outV()");
        }
    }
}
