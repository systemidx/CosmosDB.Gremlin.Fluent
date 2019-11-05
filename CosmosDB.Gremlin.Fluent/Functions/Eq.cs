using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class EqFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Predicate testing that the incoming object is equal to the provided object
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Eq(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"eq({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing that the incoming object is equal to the provided object
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Eq(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Eq((IGremlinParameter)parameter);
        }
    }
}