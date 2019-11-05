namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class CountFunction
#pragma warning restore 1591
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
