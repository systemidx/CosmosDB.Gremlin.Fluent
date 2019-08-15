namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class IdentityFunction
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