using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class InjectFunction
    {
        public static GremlinQueryBuilder Inject(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"inject({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Inject(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Inject((IGremlinParameter)parameter);
        }
    }
}