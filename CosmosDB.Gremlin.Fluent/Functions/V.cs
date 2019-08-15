using System.Linq;
using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class VFunction
#pragma warning restore 1591
    { 
        /// <summary>
        /// Inject vertices into traversal. Can filter by specified vertex ids.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder V(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return builder.Add($"V()");
            }
            else
            {
                builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
                return builder.Add($"V({parameters.Expand()})");
            }
        }
        
        /// <summary>
        /// Inject vertices into traversal. Can filter by specified vertex ids.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder V(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // common single id selection scenario for implicit conversion operators
            return builder.V((IGremlinParameter)parameter);
        }
    }
}
