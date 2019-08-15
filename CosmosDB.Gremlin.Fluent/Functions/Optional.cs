using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OptionalFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The optional()-step (branch/flatMap) returns the result of the specified traversal
        /// if it yields a result else it returns the calling element, i.e. the identity()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Optional(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));
            
            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"optional({traversal.Query})");
        }
    }
}