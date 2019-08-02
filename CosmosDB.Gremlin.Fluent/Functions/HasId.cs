using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasIdFunction
    {
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder;
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"hasId({parameters.Expand()})");
        }
    
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"hasId({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.HasId((IGremlinParameter)parameter);
        }
        
        
    }
}