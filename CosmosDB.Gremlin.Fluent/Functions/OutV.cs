namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OutVFunction
#pragma warning restore 1591
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
