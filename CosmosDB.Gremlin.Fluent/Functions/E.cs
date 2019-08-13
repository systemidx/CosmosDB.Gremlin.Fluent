using System;
using System.Linq;
using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class EFunction
    {
        /// <summary>
        /// Inject edges into traversal. Can filter by specified edge ids.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder E(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return builder.Add("E()");
            }
            else
            {
                builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
                return builder.Add($"E({parameters.Expand()})");
            }
        }
    }
}
