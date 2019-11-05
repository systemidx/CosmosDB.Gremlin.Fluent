using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class BothEFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Traverse to both the incoming and outgoing incident edges given the edge labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters">Optional edge labels</param>
        /// <returns></returns>
        public static GremlinQueryBuilder BothE(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return builder.Add("bothE()");
            }
            else
            {
                builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
                return builder.Add($"bothE({parameters.Expand()})");
            }
        }
    }
}
