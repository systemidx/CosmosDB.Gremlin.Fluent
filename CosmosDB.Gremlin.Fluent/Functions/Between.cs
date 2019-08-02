using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BetweenFunction
    {
        public static GremlinQueryBuilder Between(this GremlinQueryBuilder builder, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!start.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Between)} only supports numeric parameters and '{start.TrueValue}' does not appear to conform to this");
            if (!end.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Between)} only supports numeric parameters and '{end.TrueValue}' does not appear to conform to this");

            
            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"between({start.QueryStringValue},{end.QueryStringValue})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Between(this GremlinQueryBuilder builder, GremlinParameter start, GremlinParameter end)
        {
            return builder.Between((IGremlinParameter)start,(IGremlinParameter)end);
        }
    }
}