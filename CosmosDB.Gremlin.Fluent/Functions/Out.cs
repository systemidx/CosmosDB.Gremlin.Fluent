using System.Linq;
using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OutFunction
    {
        public static GremlinQueryBuilder Out(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder.Add($"out()");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"out({parameters.Expand()})");
        }
    }
}
