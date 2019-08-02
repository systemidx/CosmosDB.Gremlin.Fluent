using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasNotFunction
    {
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException($"{nameof(HasNot)} requires at least one parameter in {nameof(functions)}");
            
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);

            return builder.Add($"hasNot({functions.Expand()})");
        }
        
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"hasNot({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.HasNot((IGremlinParameter)parameter);
        }
    }
}