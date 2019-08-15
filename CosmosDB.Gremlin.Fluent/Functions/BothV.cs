namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class BothVFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Traverse to both vertices
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder BothV(this GremlinQueryBuilder builder)
        {
            return builder.Add("bothV()");
        }
    }
}
