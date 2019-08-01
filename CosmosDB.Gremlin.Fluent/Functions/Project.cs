using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ProjectFunction
    {
        public static GremlinQueryBuilder Project(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                return builder.Add($"project()");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"project({parameters.Expand()})");
        }
    }
}