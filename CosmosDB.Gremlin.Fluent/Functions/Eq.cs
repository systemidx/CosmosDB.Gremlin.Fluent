using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class EqFunction
    {
        public static GremlinQueryBuilder Eq(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"eq({inner.Query})");
        }

        public static GremlinQueryBuilder Eq(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"eq({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Eq(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Eq((IGremlinParameter)parameter);
        }
    }
}