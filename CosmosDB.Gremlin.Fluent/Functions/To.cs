using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ToFunction
    {
        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"to({parameter.Value})");
        }

        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            
            builder.AddArguments(func.GremlinArguments);
            return builder.Add($"to({func.Query})");
        }
    }
}
