using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FlatMapFunction
    {
        /// <summary>
        /// Map the traverser to an iterator of objects that are streamed to the next step
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inner"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder FlatMap(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                throw new ArgumentNullException(nameof(inner));
            
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"flatMap({inner.Query})");
        }
    }
}
