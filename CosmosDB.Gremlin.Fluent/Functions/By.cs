using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ByFunction
    {
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException($"{nameof(By)} requires at least one parameter in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"by({parameters.Expand()})");
        }
        
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(By)} requires at least a single parameter in {nameof(functions)}");
            
            builder.AddArguments(functions.SelectMany(f => f.GremlinArguments).ToArray());
            return builder.Add($"by({functions.Expand()})");
        }
    }
}
