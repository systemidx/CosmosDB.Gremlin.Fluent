using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasIdFunction
    {
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException($"{nameof(HasId)} requires at least one parameter in {nameof(functions)}");
            
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);

            return builder.Add($"hasId({functions.Expand()})");
        }
        
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