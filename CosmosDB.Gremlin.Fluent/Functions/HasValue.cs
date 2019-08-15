using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasValueFunction
    {
        /// <summary>
        /// Remove the traverser if its properties do not have all of the provided values
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder HasValue(this GremlinQueryBuilder builder, GremlinQueryBuilder predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            builder.AddArguments(predicate.GremlinArguments);
            return builder.Add($"hasValue({predicate.Query})");
        }
        
        /// <summary>
        /// Remove the traverser if its properties do not have all of the provided values
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder HasValue(this GremlinQueryBuilder builder, params IGremlinParameter[] values)
        {
            if (values == null || !values.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(HasValue)} requires one or more arguments to be supplied in {nameof(values)}");
            
            builder.AddArguments(values.OfType<GremlinArgument>().ToArray());
            return builder.Add($"hasValue({values.Expand()})");
        }
        
        /// <summary>
        /// Remove the traverser if its properties do not have all of the provided values
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder HasValue(this GremlinQueryBuilder builder, string value)
        {
            // for implicit conversion operators with common single label scenario
            return builder.HasValue((GremlinParameter)value);
        }
    }
}