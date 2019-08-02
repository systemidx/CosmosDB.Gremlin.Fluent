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
            if (!int.TryParse(parameter.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Gt)} only supports integer parameters '{parameter.Value}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"gt({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Gt(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Gt((IGremlinParameter)parameter);
        }
    }
}