using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class SampleFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The sample()-step is useful for sampling some number of traversers previous in the traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is int || parameter.TrueValue is uint))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Sample)} only supports integer parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"sample({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// The sample()-step is useful for sampling some number of traversers previous in the traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is int || parameter.TrueValue is uint))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Sample)} only supports integer parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"sample({scope.QueryStringValue},{parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// The sample()-step is useful for sampling some number of traversers previous in the traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, GremlinScope scope,
            int parameter)
        {
            // For implicit operators
            return builder.Sample(scope, (GremlinParameter) parameter);
        }
           
        /// <summary>
        /// The sample()-step is useful for sampling some number of traversers previous in the traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, int parameter)
        {
            // For implicit operators
            return builder.Sample((GremlinParameter) parameter);
        }
    }
}