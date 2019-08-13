using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ChooseFunction
    {
        /// <summary>
        /// The choose()-step (branch) routes the current traverser to a particular traversal branch option.
        /// With choose(), it is possible to implement if/then/else-semantics as well as more complicated selections
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="functions"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Choose(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"choose({functions.Expand()})");
        }
    }
}
