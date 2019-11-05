using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class TreeFunction
#pragma warning restore 1591
    { 
        /// <summary>
        /// From any one element (i.e. vertex or edge), the emanating paths from that element can be aggregated
        /// to form a tree. Gremlin provides tree()-step (sideEffect) for such this situation
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sideEffectKey">The name of the side-effect key that will hold the tree</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Tree(this GremlinQueryBuilder builder, IGremlinParameter sideEffectKey = null)
        {
            if (sideEffectKey == null)
                return builder.Add($"tree()");

            if (!(sideEffectKey.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tree)} only accepts {nameof(sideEffectKey)} that resolves to a string " +
                    $"and {sideEffectKey.TrueValue} does not");
            
            builder.AddArgument(sideEffectKey as GremlinArgument);
            return builder.Add($"tree({sideEffectKey.QueryStringValue})");
        }
        
        /// <summary>
        /// From any one element (i.e. vertex or edge), the emanating paths from that element can be aggregated
        /// to form a tree. Gremlin provides tree()-step (sideEffect) for such this situation
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sideEffectKey">The name of the side-effect key that will hold the tree</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Tree(this GremlinQueryBuilder builder, string sideEffectKey)
        {
            // common scenario overload
            return builder.Tree((GremlinParameter)sideEffectKey);
        }
    }
}