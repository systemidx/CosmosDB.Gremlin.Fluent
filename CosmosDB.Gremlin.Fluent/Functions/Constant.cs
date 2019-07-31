using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ConstantFunction
    {
        public static GremlinQueryBuilder Constant(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"constant({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Constant(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Constant((IGremlinParameter)parameter);
        }
    }
}
