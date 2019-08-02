using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasIdFunction
    {
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException($"{nameof(HasId)} requires at least one parameter in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"hasId({parameters.Expand()})");
        }
    
        // for implicit conversion operators
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.HasId((IGremlinParameter)parameter);
        }
        
        
    }
}