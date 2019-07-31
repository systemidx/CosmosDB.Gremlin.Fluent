using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasLabelFunction
    {
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"hasLabel({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.HasLabel((IGremlinParameter)parameter);
        }
    }
}
