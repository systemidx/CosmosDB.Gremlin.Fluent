using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ValueMapFunction
    {
        public static GremlinQueryBuilder ValueMap(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is bool) && !(bool.TryParse(parameter.TrueValue.ToString(), out _)))
                throw new GremlinQueryBuilderException(
                    $"{nameof(ValueMap)} only supports boolean parameters and '{parameter.TrueValue}' does not appear to be");
            
            return builder.Add($"valueMap({parameter.QueryStringValue})");
        }
        
    }
}