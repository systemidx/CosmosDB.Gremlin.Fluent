using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class EFunction
    { 
        public static GremlinQueryBuilder E(this GremlinQueryBuilder builder, GremlinParameter value = null)
        {
            if (value == null)
                return builder.Add($"E()");

            return builder.Add($"E({value.Value})");
        }
    }
}
