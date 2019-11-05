using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class LtFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Predicate testing if the incoming number is less than the argument numeric value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Lt(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Lt)} only supports numeric parameters and '{parameter.TrueValue}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"lt({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing if the incoming number is less than the argument numeric value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Lt(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Lt((IGremlinParameter)parameter);
        }
    }
}