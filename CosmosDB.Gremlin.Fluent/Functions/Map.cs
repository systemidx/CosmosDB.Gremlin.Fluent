using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class MapFunction
    {
        /// <summary>
        /// Map the traverser to an objects for the next step to process
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inner"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Map(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                throw new ArgumentNullException(nameof(inner));
            
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"map({inner.Query})");
        }
    }
}
