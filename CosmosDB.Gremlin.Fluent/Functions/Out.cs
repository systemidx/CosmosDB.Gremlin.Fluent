using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class OutFunction
    {
        public static GremlinQueryBuilder Out(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"out({parameters.Expand()})");
        }
    }
}
