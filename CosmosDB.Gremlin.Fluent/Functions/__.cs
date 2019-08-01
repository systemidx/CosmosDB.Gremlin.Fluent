namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class __Function
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