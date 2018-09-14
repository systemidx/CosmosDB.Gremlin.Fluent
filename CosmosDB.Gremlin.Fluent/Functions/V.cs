using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class VFunction
    { 
        public static GremlinQueryBuilder V(this GremlinQueryBuilder builder, GremlinParameter value = null)
        {
            if (value == null)
                return builder.Add($"V()");

            return builder.Add($"V({value.Value})");
        }
    }
}
