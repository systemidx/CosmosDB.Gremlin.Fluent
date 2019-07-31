using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasNotFunction
    {
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"hasNot({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.HasNot((IGremlinParameter)parameter);
        }
    }
}