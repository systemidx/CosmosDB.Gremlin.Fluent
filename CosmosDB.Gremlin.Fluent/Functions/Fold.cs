namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FoldFunction
    {
        /// <summary>
        /// There are situations when the traversal stream needs a "barrier" to aggregate all the objects and emit a
        /// computation that is a function of the aggregate.
        /// The fold()-step (map) is one particular instance of this.
        /// Please see <seealso cref="UnfoldFunction.Unfold"/> for the inverse functionality
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Fold(this GremlinQueryBuilder builder)
        {
            return builder.Add("fold()");
        }
    }
}
