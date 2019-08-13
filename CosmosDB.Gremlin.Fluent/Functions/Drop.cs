namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class DropFunction
    {
        /// <summary>
        /// The drop()-step (filter/sideEffect) is used to remove element and properties from the graph (i.e. remove).
        /// It is a filter step because the traversal yields no outgoing objects
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Drop(this GremlinQueryBuilder builder)
        {
            return builder.Add("drop()");
        }
    }
}
