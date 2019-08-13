using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class WhereFunction
    {
        /// <summary>
        /// The where()-step filters the current object based on either the object itself (Scope.local)
        /// or the path history of the object (Scope.global) (filter).
        /// This step is typically used in conjunction with either match()-step (not supported in CosmosDb)
        /// or select()-step, but can be used in isolation
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversalOrPredicate"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Where(this GremlinQueryBuilder builder, GremlinQueryBuilder traversalOrPredicate)
        {
            if (traversalOrPredicate == null)
                throw new ArgumentNullException(nameof(traversalOrPredicate));
            
            builder.AddArguments(traversalOrPredicate.GremlinArguments);
            return builder.Add($"where({traversalOrPredicate.Query})");
        }

        /// <summary>
        /// The where()-step filters the current object based on either the object itself (Scope.local)
        /// or the path history of the object (Scope.global) (filter).
        /// This step is typically used in conjunction with either match()-step (not supported in CosmosDb)
        /// or select()-step, but can be used in isolation
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="key"></param>
        /// <param name="traversalOrPredicate"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Where(this GremlinQueryBuilder builder, IGremlinParameter key, GremlinQueryBuilder traversalOrPredicate)
        {
            if (traversalOrPredicate == null)
                throw new ArgumentNullException(nameof(traversalOrPredicate));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (!(key.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Where)} only supports string values as {nameof(key)} " +
                    $"and {key.TrueValue} does not appear to be");
            
            builder.AddArguments(traversalOrPredicate.GremlinArguments);
            return builder.Add($"where({traversalOrPredicate.Query})");
        }
    }
}
