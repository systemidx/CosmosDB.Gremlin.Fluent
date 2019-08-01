using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class NotFunction
    {
        public static GremlinQueryBuilder Not(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                throw new ArgumentNullException(nameof(inner),$"{nameof(inner)} cannot be null");
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"not({inner.Query})");
        }
    }
}