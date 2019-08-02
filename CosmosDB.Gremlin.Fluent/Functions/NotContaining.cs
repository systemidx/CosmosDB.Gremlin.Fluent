using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NotContainingFunction
    {
        public static GremlinQueryBuilder NotContaining(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"notContaining({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder NotContaining(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.NotContaining((IGremlinParameter)parameter);
        }
    }
}