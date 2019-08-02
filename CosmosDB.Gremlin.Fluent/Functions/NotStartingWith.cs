using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NotStartingWithFunction
    {
        public static GremlinQueryBuilder NotStartingWith(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"notStartingWith({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder NotStartingWith(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.NotStartingWith((IGremlinParameter)parameter);
        }
    }
}