using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasLabelFunction
    {
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException($"{nameof(HasLabel)} requires at least one parameter in {nameof(functions)}");
            
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);

            return builder.Add($"hasLabel({functions.Expand()})");
        }
        
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"hasLabel({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.HasLabel((IGremlinParameter)parameter);
        }
    }
}
