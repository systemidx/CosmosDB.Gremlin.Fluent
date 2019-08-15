using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class NotContainingFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Predicate testing that the incoming string does not contain the provided string argument value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder NotContaining(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(NotContaining)} only accepts parameters that resolve to string and {parameter.TrueValue} does not appear to");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"notContaining({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing that the incoming string does not contain the provided string argument value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder NotContaining(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.NotContaining((GremlinParameter)parameter);
        }
    }
}