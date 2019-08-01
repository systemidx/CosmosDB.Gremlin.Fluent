using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ValuesFunction
    {
        public static GremlinQueryBuilder Values(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder.Add($"values()");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"values({parameters.Expand()})");
        }
    }
}