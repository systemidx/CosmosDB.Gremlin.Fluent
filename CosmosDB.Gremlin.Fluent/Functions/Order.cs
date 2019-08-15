namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OrderFunction
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