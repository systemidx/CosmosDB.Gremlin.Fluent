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
            if (!long.TryParse(start.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{start.Value}' does not appear to conform to this");
            if (!long.TryParse(end.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{end.Value}' does not appear to conform to this");
            
            return builder.Add($"range({start.Value},{end.Value})");
        }
        
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!long.TryParse(start.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{start.Value}' does not appear to conform to this");
            if (!long.TryParse(end.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{end.Value}' does not appear to conform to this");

            return builder.Add($"range({scope.Value},{start.Value},{end.Value})");
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