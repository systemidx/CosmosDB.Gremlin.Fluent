using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class VFunction
    { 
        public static GremlinQueryBuilder V(this GremlinQueryBuilder builder, IGremlinParameter value = null)
        {
            if (value == null)
                return builder.Add($"V()");
            
            builder.AddArgument(value as GremlinArgument);
            return builder.Add($"V({value.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder V(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.V((IGremlinParameter)parameter);
        }
    }
}
