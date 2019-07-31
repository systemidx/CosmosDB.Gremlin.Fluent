using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AndFunction
    {
        public static GremlinQueryBuilder And(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"and({functions.Expand()})");
        }
    }
}
