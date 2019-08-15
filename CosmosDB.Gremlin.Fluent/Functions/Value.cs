namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ValueFunction
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