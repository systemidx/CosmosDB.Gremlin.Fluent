using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class StoreFunction
    {
        public static GremlinQueryBuilder Store(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"store({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Store(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Store((IGremlinParameter)parameter);
        }
    }
}