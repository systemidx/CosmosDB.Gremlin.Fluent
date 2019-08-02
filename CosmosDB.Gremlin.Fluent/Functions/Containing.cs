using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ContainingFunction
    {
        public static GremlinQueryBuilder Containing(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"containing({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Containing(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Containing((IGremlinParameter)parameter);
        }
    }
}