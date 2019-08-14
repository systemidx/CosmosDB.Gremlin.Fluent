using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class IsFunction
    {
        /// <summary>
        /// Filter scalar values if they are not equal to the provided value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Is(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"is({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Filter scalar values if they are not equal to the provided value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Is(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Is((IGremlinParameter)parameter);
        }
        
        /// <summary>
        /// Filter scalar values if they do not satisfy the provided predicate
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Is(this GremlinQueryBuilder builder, GremlinQueryBuilder predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            builder.AddArguments(predicate.GremlinArguments);
            return builder.Add($"is({predicate.Query})");
        }
    }
}