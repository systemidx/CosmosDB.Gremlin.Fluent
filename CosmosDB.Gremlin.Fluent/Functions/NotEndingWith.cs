using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NotEndingWithFunction
    {
        public static GremlinQueryBuilder NotEndingWith(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"notEndingWith({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder NotEndingWith(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.NotEndingWith((IGremlinParameter)parameter);
        }
    }
}