namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinScope
    {
        public string QueryStringValue { get; }

        public GremlinScope(string scopeName)
        {
            QueryStringValue = scopeName;
        }

        public static GremlinScope Local => new GremlinScope("local");
    }
}