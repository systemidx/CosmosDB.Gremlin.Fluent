using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CapFunction
    {
        public static GremlinQueryBuilder Cap(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"cap({parameters.Expand()})");
        }
    }
}
