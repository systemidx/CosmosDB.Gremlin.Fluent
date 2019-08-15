namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class PathFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// A traverser is transformed as it moves through a series of steps within a traversal.
        /// The history of the traverser is realized by examining its path with path()-step (map)
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Path(this GremlinQueryBuilder builder)
        {
            return builder.Add("path()");
        }
    }
}