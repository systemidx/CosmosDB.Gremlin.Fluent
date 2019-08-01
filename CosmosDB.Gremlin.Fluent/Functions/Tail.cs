using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class TailFunction
    {
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!int.TryParse(parameter.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tail)} only supports integer parameters and scope and '{parameter.Value}' does not appear to conform to this");
            
            return builder.Add($"tail({parameter.Value})");
        }
        
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinScope scope, GremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!int.TryParse(parameter.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tail)} only supports integer parameters and scope and '{parameter.Value}' does not appear to conform to this");

            return builder.Add($"tail({scope.Value},{parameter.Value})");
        }
    }
}