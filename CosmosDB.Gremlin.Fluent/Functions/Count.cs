namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CountFunction
    {
        /// <summary>
        /// The count()-step (map) counts the total number of represented traversers in the streams (i.e. the bulk count).
        /// All the incoming traversers are folded into new traverser whose path starts at count()
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Count(this GremlinQueryBuilder builder)
        {
            return builder.Add("count()");
        }
    }
}
