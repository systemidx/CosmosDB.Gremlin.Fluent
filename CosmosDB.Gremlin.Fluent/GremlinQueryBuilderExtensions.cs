using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Extension methods for Gremlin query builder
    /// </summary>
    public static class GremlinQueryBuilderExtensions
    {
        /// <summary>
        /// Combine multiple query builders as traversals/predicates into a single query string
        /// </summary>
        /// <param name="innerBuilders"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static string Expand(this GremlinQueryBuilder[] innerBuilders)
        {
            if (innerBuilders == null)
                throw new GremlinQueryBuilderException($"{nameof(Expand)} requires {nameof(innerBuilders)}");

            if (innerBuilders.Length == 0)
                return string.Empty;

            return string.Join(",", innerBuilders.Select(b => b.Query));
        }
        
        /// <summary>
        /// Generate gremlin argument from supplied name/value pair.
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public static GremlinArgument ToGremlinArgument(this KeyValuePair<string, object> pair)
        {
            return new GremlinArgument(pair.Key, pair.Value);
        }
        
        
    }
}