using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class LteFunction
    {
        /// <summary>
        /// Predicate testing if the incoming number is less than or equal to the argument numeric value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Lte(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Lte)} only supports numeric parameters and '{parameter.TrueValue}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"lte({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing if the incoming number is less than or equal to the argument numeric value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Lte(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Lte((IGremlinParameter)parameter);
        }
    }
}