using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class TailFunction
    {
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tail)} only supports numeric parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"tail({parameter.QueryStringValue})");
        }
        
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!parameter.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tail)} only supports numeric parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"tail({scope.Value},{parameter.QueryStringValue})");
        }
        
        // For implicit operators
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinScope scope,
            GremlinParameter parameter)
        {
            return builder.Tail(scope, (IGremlinParameter) parameter);
        }
           
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Tail((IGremlinParameter) parameter);
        }
    }
}