using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AsFunction
    {
        public static GremlinQueryBuilder As(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"as({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder As(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.As((IGremlinParameter)parameter);
        }
    }
}
