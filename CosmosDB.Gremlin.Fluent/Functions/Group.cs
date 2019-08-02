using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class GroupFunction
    { 
        public static GremlinQueryBuilder Group(this GremlinQueryBuilder builder, IGremlinParameter value = null)
        {
            if (value == null)
                return builder.Add($"group()");
            
            builder.AddArgument(value as GremlinArgument);
            return builder.Add($"group({value.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Group(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Group((IGremlinParameter)parameter);
        }
    }
}