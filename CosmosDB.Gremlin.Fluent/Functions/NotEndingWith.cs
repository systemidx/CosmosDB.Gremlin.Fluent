using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NotEndingWithFunction
    {
        /// <summary>
        /// String predicate that tests incoming string to see if it does not end with specified argument string value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder NotEndingWith(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(NotEndingWith)} requires {nameof(parameter)} to " +
                                                       $"be a string and {parameter.TrueValue} does not appear to be");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"notEndingWith({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// String predicate that tests incoming string to see if it does not end with specified argument string value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder NotEndingWith(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.NotEndingWith((GremlinParameter)parameter);
        }
    }
}