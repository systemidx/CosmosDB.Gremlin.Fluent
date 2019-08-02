using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddVFunction
    {
        public static GremlinQueryBuilder AddV(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"addV({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder AddV(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.AddV((IGremlinParameter)parameter);
        }
    }
}
