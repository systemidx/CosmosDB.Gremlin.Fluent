using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class NotFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The not()-step (filter) removes objects from the traversal stream when the traversal
        /// provided as an argument returns an object
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder Not(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal),$"{nameof(traversal)} cannot be null");
            
            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"not({traversal.Query})");
        }
    }
}