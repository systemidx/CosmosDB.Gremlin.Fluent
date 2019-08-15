using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class WithinFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Predicate testing if the incoming object is within array of provided objects
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Within(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Within)} requires at least one argument in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"within({parameters.Expand()})");
        }
    }
}