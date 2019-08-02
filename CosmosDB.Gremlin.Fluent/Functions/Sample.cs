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
            if (!int.TryParse(parameter.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Sample)} only supports integer parameters and scope and '{parameter.Value}' does not appear to conform to this");
            
            return builder.Add($"sample({parameter.Value})");
        }
        
        public static GremlinQueryBuilder Sample(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!int.TryParse(parameter.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Sample)} only supports integer parameters and scope and '{parameter.Value}' does not appear to conform to this");

            return builder.Add($"sample({scope.Value},{parameter.Value})");
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