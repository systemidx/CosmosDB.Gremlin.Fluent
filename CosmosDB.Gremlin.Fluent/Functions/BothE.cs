using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BothEFunction
    {
        public static GremlinQueryBuilder BothE(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder;
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"bothE({parameters.Expand()})");
        }
    }
}
