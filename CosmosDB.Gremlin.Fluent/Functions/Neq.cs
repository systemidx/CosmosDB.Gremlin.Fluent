using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NeqFunction
    {
        /// <summary>
        /// Predicate testing that the incoming object is not equal to the provided object
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Neq(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"neq({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate testing that the incoming object is not equal to the provided object
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Neq(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Neq((IGremlinParameter)parameter);
        }
    }
}
