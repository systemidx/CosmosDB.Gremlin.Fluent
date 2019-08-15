namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class InVFunction
#pragma warning restore 1591
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
