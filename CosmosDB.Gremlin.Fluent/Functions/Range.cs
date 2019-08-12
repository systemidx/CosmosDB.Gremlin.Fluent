using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class RangeFunction
    {
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!start.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{start.TrueValue}' does not appear to conform to this");
            if (!end.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{end.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"range({start.QueryStringValue},{end.QueryStringValue})");
        }
        
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!start.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{start.TrueValue}' does not appear to conform to this");
            if (!end.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{end.TrueValue}' does not appear to conform to this");

            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"range({scope.QueryStringValue},{start.QueryStringValue},{end.QueryStringValue})");
        }
        
        // For implicit operators
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, GremlinParameter start, GremlinParameter end)
        {
            return builder.Range((IGremlinParameter) start, (IGremlinParameter) end);
        }
        
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, GremlinScope scope, GremlinParameter start, GremlinParameter end)
        {
            return builder.Range(scope, (IGremlinParameter) start, (IGremlinParameter) end);
        }

    }
}