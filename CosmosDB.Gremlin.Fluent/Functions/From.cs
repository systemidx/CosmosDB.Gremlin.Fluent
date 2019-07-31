using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class FromFunction
    {
        public static GremlinQueryBuilder From(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"from({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder From(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.From((IGremlinParameter)parameter);
        }

        public static GremlinQueryBuilder From(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            
            builder.AddArguments(func.GremlinArguments);
            return builder.Add($"from({func.Query})");
        }
    }
}