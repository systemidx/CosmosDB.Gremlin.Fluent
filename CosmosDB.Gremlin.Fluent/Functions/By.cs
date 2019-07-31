using System;
using System.Collections.Generic;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ByFunction
    {
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"by({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.By((IGremlinParameter)parameter);
        }

        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            
            builder.AddArguments(func.GremlinArguments);
            return builder.Add($"by({func.Query})");
        }
    }
}
