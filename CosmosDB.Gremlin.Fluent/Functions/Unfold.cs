namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class UnfoldFunction
#pragma warning restore 1591
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
