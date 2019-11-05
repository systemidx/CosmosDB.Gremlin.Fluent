namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class ValueFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The value()-step (map) takes a Property and extracts the value from it
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Value(this GremlinQueryBuilder builder)
        {
            return builder.Add("value()");
        }
    }
}