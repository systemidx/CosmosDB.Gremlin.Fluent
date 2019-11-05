using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class StoreFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Lazily aggregates objects in the stream into a side-effect collection
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sideEffectKey">The name of the side-effect key that will hold the aggregate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Obsolete("As of TinkerPop 3.4.3, replaced by aggregate(Scope, String) using Scope.local",false)]
        public static GremlinQueryBuilder Store(this GremlinQueryBuilder builder, IGremlinParameter sideEffectKey)
        {
            if (sideEffectKey == null)
                throw new ArgumentNullException(nameof(sideEffectKey));
            if (!(sideEffectKey.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(Store)} requires {nameof(sideEffectKey)} " +
                                                       $"to resolve to a string and {sideEffectKey.TrueValue} does not");
            
            builder.AddArgument(sideEffectKey as GremlinArgument);
            return builder.Add($"store({sideEffectKey.QueryStringValue})");
        }
        
        /// <summary>
        /// Lazily aggregates objects in the stream into a side-effect collection
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sideEffectKey">The name of the side-effect key that will hold the aggregate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Obsolete("As of TinkerPop 3.4.3, replaced by aggregate(Scope, String) using Scope.local",false)]
        public static GremlinQueryBuilder Store(this GremlinQueryBuilder builder, string sideEffectKey)
        {
            return builder.Store((GremlinParameter)sideEffectKey);
        }
    }
}