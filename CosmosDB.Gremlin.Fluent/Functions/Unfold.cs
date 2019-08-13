namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class UnfoldFunction
    {
        /// <summary>
        /// If the object reaching unfold() (flatMap) is an iterator, iterable, or map,
        /// then it is unrolled into a linear form. If not, then the object is simply emitted.
        /// Please see <seealso cref="FoldFunction.Fold"/> step for the inverse behavior
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Unfold(this GremlinQueryBuilder builder)
        {
            return builder.Add("unfold()");
        }
    }
}
