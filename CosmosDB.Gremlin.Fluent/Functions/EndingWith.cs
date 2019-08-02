using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class EndingWithFunction
    {
        public static GremlinQueryBuilder EndingWith(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"endingWith({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder EndingWith(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.EndingWith((IGremlinParameter)parameter);
        }
    }
}