using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class PropertiesFunction
    {
        public static GremlinQueryBuilder Properties(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder.Add($"properties()");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"properties({parameters.Expand()})");
        }
    }
}