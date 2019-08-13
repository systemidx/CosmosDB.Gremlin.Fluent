namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BothVFunction
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
