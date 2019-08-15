namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OrderFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The order()-step allows the user to provide an arbitrary number of comparators for primary, secondary, etc. sorting.
        /// Typically followed by one or more calls to <seealso cref="ByFunction.By(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter[])"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Order(this GremlinQueryBuilder builder)
        {
            return builder.Add("order()");
        }
    }
}