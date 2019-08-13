using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class RepeatFunction
    {
        /// <summary>
        /// The repeat()-step (branch) is used for looping over a traversal given some break predicate
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Repeat(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));
            
            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"repeat({traversal.Query})");
        }
    }
}