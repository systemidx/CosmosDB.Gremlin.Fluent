using System.Collections.Generic;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BranchFunction
    {
        public static GremlinQueryBuilder Branch(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            
            builder.AddArguments(inner?.GremlinArguments ?? new List<GremlinArgument>(0));
            return builder.Add($"branch({inner.Query})");
        }
    }
}
