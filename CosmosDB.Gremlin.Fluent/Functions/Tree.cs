using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class TreeFunction
    { 
        public static GremlinQueryBuilder Tree(this GremlinQueryBuilder builder, IGremlinParameter sideEffectKey = null)
        {
            if (sideEffectKey == null)
                return builder.Add($"tree()");
            
            builder.AddArgument(sideEffectKey as GremlinArgument);
            return builder.Add($"tree({sideEffectKey.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Tree(this GremlinQueryBuilder builder, GremlinParameter sideEffectKey)
        {
            return builder.Tree((IGremlinParameter)sideEffectKey);
        }
    }
}