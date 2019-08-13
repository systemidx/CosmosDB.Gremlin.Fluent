using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class WithoutFunction
    {
        /// <summary>
        /// Predicate testing if the incoming object is within array of provided objects
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Without(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Without)} requires at least one argument in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"without({parameters.Expand()})");
        }
    }
}