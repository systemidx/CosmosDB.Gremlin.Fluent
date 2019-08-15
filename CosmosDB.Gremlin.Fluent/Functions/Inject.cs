using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InjectFunction
    {
        /// <summary>
        /// Insert object arbitrarily into a traversal stream
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder Inject(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"inject({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// Insert object arbitrarily into a traversal stream
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Inject(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.Inject((IGremlinParameter)parameter);
        }
    }
}