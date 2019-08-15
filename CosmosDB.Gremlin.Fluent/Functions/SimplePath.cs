namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class SimplePathFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// When it is important that a traverser not repeat its path through the graph,
        /// simplePath()-step should be used (filter). The path information of the traverser is analyzed and
        /// if the path has repeated objects in it, the traverser is filtered.
        /// If cyclic behavior is desired, see <seealso cref="CyclicPathFunction.CyclicPath"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder SimplePath(this GremlinQueryBuilder builder)
        {
            return builder.Add("simplePath()");
        }
    }
}