using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasFunction
    {
        public static GremlinQueryBuilder Has(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] functions)
        {
            if (functions == null || !functions.Any())
                throw new GremlinQueryBuilderException($"{nameof(Has)} requires at least one parameter in {nameof(functions)}");
            
            builder.AddArguments(functions?.SelectMany(f => f.GremlinArguments).ToArray() ?? new GremlinArgument[0]);

            return builder.Add($"has({functions.Expand()})");
        }
        
        public static GremlinQueryBuilder Has(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder;
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"has({parameters.Expand()})");
        }
    }
}
