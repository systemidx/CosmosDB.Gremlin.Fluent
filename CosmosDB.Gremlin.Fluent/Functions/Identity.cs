namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class IdentityFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The identity()-step (map) is an identity function which maps the current object to itself
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Identity(this GremlinQueryBuilder builder)
        {
            return builder.Add($"identity()");
        }
    }
}