namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinComparator : IGremlinParameter
    {
        public virtual string QueryStringValue { get; }
        public virtual object TrueValue => QueryStringValue;

        public GremlinComparator(string tokenValue)
        {
            QueryStringValue = tokenValue;
        }

        public static GremlinComparator Incr => new GremlinComparator("incr");
        public static GremlinComparator Decr => new GremlinComparator("decr");
    }
}