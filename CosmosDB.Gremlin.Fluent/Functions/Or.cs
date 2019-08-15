using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OrFunction
    {
        /// <summary>
        /// The or()-step ensures that at least one of the provided traversals yield a result (filter).
        /// The or()-step can take an arbitrary number of traversals. At least one of the traversals must
        /// produce at least one output for the original traverser to pass to the next step.
        /// An infix notation can be used as well
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="functions"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Or(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                return builder.Add("or()"); // for infix notation
            
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"or({functions.Expand()})");
        }
    }
}