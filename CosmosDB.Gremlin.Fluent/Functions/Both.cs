using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class BothFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Traverse to both incoming and outgoing vertices. Optionally supports edge labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters">Optional edge labels</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Both(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return builder.Add("both()");
            }
            else
            {
                builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
                return builder.Add($"both({parameters.Expand()})");
            }
        }
    }
}
