namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CyclicPathFunction
    {
        /// <summary>
        /// Each traverser maintains its history through the traversal over the graph — i.e. its path.
        /// If it is important that the traverser repeat its course, then cyclic()-path should be used (filter).
        /// The step analyzes the path of the traverser thus far and if there are any repeats,
        /// the traverser is filtered out over the traversal computation.
        /// If non-cyclic behavior is desired, see <seealso cref="SimplePathFunction.SimplePath"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder CyclicPath(this GremlinQueryBuilder builder)
        {
            return builder.Add("cyclicPath()");
        }
    }
}
