using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ContainingFunction
    {
        /// <summary>
        /// Predicate testing that the incoming string contains the provided string argument value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder Containing(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Containing)} only accepts parameters that resolve to string and {parameter.TrueValue} does not appear to");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"containing({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing that if the incoming string contains the provided argument
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder Containing(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.Containing((GremlinParameter)parameter);
        }
    }
}