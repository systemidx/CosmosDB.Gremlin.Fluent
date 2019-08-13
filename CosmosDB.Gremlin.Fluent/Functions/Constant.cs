using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ConstantFunction
    {
        /// <summary>
        /// To specify a constant value for a traverser, use the constant()-step (map).
        /// This is often useful with conditional steps like choose()-step or coalesce()-step
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder Constant(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"constant({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// To specify a constant value for a traverser, use the constant()-step (map).
        /// This is often useful with conditional steps like choose()-step or coalesce()-step
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder Constant(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Constant((IGremlinParameter)parameter);
        }
    }
}
