using System;
using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class EFunction
    { 
        public static GremlinQueryBuilder E(this GremlinQueryBuilder builder, IGremlinParameter parameter = null)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"E({parameter.Value})");
        }
    }
}
