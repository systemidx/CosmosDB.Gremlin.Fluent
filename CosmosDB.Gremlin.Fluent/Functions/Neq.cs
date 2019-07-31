using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NeqFunction
    {
        public static GremlinQueryBuilder Neq(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"neq({inner.Query})");
        }

        public static GremlinQueryBuilder Neq(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"neq({parameter.Value})");
        }
    }
}
