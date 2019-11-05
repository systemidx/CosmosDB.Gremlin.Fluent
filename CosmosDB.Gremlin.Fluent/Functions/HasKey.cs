using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class HasKeyFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Remove the traverser if its properties do not have all of the provided keys
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder HasKey(this GremlinQueryBuilder builder, GremlinQueryBuilder predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            builder.AddArguments(predicate.GremlinArguments);
            return builder.Add($"hasKey({predicate.Query})");
        }
        
        /// <summary>
        /// Remove the traverser if its properties do not have all of the provided keys
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder HasKey(this GremlinQueryBuilder builder, params IGremlinParameter[] keys)
        {
            if (keys == null || !keys.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(HasKey)} requires one or more arguments to be supplied in {nameof(keys)}");
            if (!keys.All(v => v.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(HasKey)} only accepts arguments that resolve to strings in {nameof(keys)}");
            
            builder.AddArguments(keys.OfType<GremlinArgument>().ToArray());
            return builder.Add($"hasKey({keys.Expand()})");
        }
        
        /// <summary>
        /// Remove the traverser if its properties do not have all of the provided keys
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder HasKey(this GremlinQueryBuilder builder, string key)
        {
            // for implicit conversion operators with common single label scenario
            return builder.HasKey((GremlinParameter)key);
        }
    }
}