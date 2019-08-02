using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class LtFunction
    {
        public static GremlinQueryBuilder Lt(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"lt({inner.Query})");
        }

        public static GremlinQueryBuilder Lt(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Lt)} only supports numeric parameters and '{parameter.TrueValue}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"lt({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Lt(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Lt((IGremlinParameter)parameter);
        }
    }
}