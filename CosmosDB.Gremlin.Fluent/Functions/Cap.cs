using System.Linq;
using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CapFunction
    {
        /// <summary>
        /// The cap()-step (barrier) iterates the traversal up to itself and emits the sideEffect
        /// referenced by the provided key. If multiple keys are provided, then a Map&lt;String,Object&gt;
        /// of sideEffects is emitted.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Cap(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder;
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"cap({parameters.Expand()})");
        }
    }
}
