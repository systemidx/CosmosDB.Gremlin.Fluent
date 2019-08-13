using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class UnionFunction
    {
        /// <summary>
        /// The union()-step (branch) supports the merging of the results of an arbitrary number of traversals.
        /// When a traverser reaches a union()-step, it is copied to each of its internal steps.
        /// The traversers emitted from union() are the outputs of the respective internal traversals
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversals"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Union(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] traversals)
        {
            if (traversals == null || !traversals.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Union)} requires at least one parameter in {nameof(traversals)}");
            builder.AddArguments(traversals?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"union({traversals.Expand()})");
        }
    }
}