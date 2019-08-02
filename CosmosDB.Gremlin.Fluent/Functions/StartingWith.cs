using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class StartingWithFunction
    {
        public static GremlinQueryBuilder StartingWith(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"startingWith({parameter.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder StartingWith(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.StartingWith((IGremlinParameter)parameter);
        }
    }
}