namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinComparator : IGremlinParameter
    {
        public string Value { get; }

        public GremlinComparator(string tokenValue)
        {
            Value = tokenValue;
        }

        public static GremlinComparator Incr => new GremlinComparator("incr");
        public static GremlinComparator Decr => new GremlinComparator("decr");
    }
}