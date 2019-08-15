using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class GtFunction
    {
        /// <summary>
        /// Predicate testing if the incoming number is greater than the argument numeric value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Gt(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Gt)} only supports numeric parameters and '{parameter.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"gt({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing if the incoming number is greater than the argument numeric value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Gt(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Gt((IGremlinParameter)parameter);
        }
    }
}