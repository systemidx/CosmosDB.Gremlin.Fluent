using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class DedupFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// With dedup()-step (filter), repeatedly seen objects are removed from the traversal stream. N
        /// ote that if a traverser’s bulk is greater than 1, then it is set to 1 before being emitted.
        /// If dedup() is provided an array of strings, then it will ensure that the de-duplication is not
        /// with respect to the current traverser object, but to the path history of the traverser
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Dedup(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return builder.Add("dedup()");
            }
            else
            {
                if (!parameters.All(p => p.TrueValue is string))
                    throw new GremlinQueryBuilderException(
                        $"{nameof(Dedup)} requires all parameters supplied to {nameof(parameters)} to be strings");
                
                builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
                return builder.Add($"dedup({parameters.Expand()})");
            }
        }

        /// <summary>
        /// With dedup()-step (filter), repeatedly seen objects are removed from the traversal stream. N
        /// ote that if a traverser’s bulk is greater than 1, then it is set to 1 before being emitted.
        /// If dedup() is provided an array of strings, then it will ensure that the de-duplication is not
        /// with respect to the current traverser object, but to the path history of the traverser
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Dedup(this GremlinQueryBuilder builder, GremlinScope scope, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return builder.Add("dedup()");
            }
            else
            {
                if (!parameters.All(p => p.TrueValue is string))
                    throw new GremlinQueryBuilderException(
                        $"{nameof(Dedup)} requires all parameters supplied to {nameof(parameters)} to be strings");
                
                builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
                return builder.Add($"dedup({scope.QueryStringValue},{parameters.Expand()})");
            }
        }

    }
}
