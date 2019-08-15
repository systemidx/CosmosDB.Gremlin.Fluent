namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class LocalFunction
    {
        /// <summary>
        /// A GraphTraversal operates on a continuous stream of objects. In many situations, it is important to
        /// operate on a single element within that stream.
        /// To do such object-local traversal computations, local()-step exists (branch)
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inner"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Local(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"local({inner.Query})");
        }
    }
}