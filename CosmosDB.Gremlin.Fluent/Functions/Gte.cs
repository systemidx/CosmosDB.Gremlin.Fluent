using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class GteFunction
    {
        public static GremlinQueryBuilder Gte(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"gte({inner.Query})");
        }

        public static GremlinQueryBuilder Gte(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Gte)} only supports numeric parameters and '{parameter.TrueValue}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"gte({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Gte(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Gte((IGremlinParameter)parameter);
        }
    }
}