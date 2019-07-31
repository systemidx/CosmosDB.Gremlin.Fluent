using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OutEFunction
    {
        public static GremlinQueryBuilder OutE(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder;
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"outE({parameters.Expand()})");
        }
    }
}
