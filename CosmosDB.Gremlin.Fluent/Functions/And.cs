using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class AndFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The and()-step ensures that all provided traversals yield a result
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="functions"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder And(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
            {
                // infix notation support
                return builder.Add($"and()");
            }
            else
            {
                builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
                return builder.Add($"and({functions.Expand()})");
            }
        }
    }
}
