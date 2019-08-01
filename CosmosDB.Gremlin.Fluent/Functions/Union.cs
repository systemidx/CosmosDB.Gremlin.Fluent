using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class UnionFunction
    {
        public static GremlinQueryBuilder Union(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Union)} requires at least one parameter in {nameof(functions)}");
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);
            return builder.Add($"union({functions.Expand()})");
        }
    }
}