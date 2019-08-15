using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class CoalesceFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The coalesce()-step evaluates the provided traversals in order and returns the first
        /// traversal that emits at least one element
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="functions"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Coalesce(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException($"{nameof(Coalesce)} requires at least one parameter to be present in {nameof(functions)}");
            
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"coalesce({functions.Expand()})");
        }
    }
}
