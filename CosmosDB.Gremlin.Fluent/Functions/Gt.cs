using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class GtFunction
    {
        public static GremlinQueryBuilder Gt(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"gt({inner.Query})");
        }

        public static GremlinQueryBuilder Gt(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Gt)} only supports numeric parameters and '{parameter.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"gt({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Gt(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Gt((IGremlinParameter)parameter);
        }
    }
}