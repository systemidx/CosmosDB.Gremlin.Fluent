namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class __Function
#pragma warning restore 1591
    {
        /// <summary>
        /// Anonymous graph traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder __(this GremlinQueryBuilder builder)
        {
            return builder.Add("__");
        }
    }
}