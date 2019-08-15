namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OtherVFunction
#pragma warning restore 1591
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
