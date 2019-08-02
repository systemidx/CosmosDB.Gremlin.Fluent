using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class CoinFunction
    {
        public static GremlinQueryBuilder Coin(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"coin({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Coin(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Coin((IGremlinParameter)parameter);
        }
    }
}
