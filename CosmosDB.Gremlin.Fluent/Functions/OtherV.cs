namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OtherVFunction
    {
        /// <summary>
        /// Move to the vertex that was not the vertex that was moved from
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder OtherV(this GremlinQueryBuilder builder)
        {
            return builder.Add("otherV()");
        }
    }
}
