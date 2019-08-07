using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class SampleFunction
    {
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is int || parameter.TrueValue is uint))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Sample)} only supports integer parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");
            builder.AddArgument(parameter as GremlinArgument);
            
            return builder.Add($"sample({parameter.QueryStringValue})");
        }
        
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is int || parameter.TrueValue is uint))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Sample)} only supports integer parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");
            builder.AddArgument(parameter as GremlinArgument);
            
            return builder.Add($"sample({scope.Value},{parameter.QueryStringValue})");
        }
        
        // For implicit operators
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, GremlinScope scope,
            GremlinParameter parameter)
        {
            return builder.Sample(scope, (IGremlinParameter) parameter);
        }
           
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Sample((IGremlinParameter) parameter);
        }
    }
}