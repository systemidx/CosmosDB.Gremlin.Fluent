namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinScope : IGremlinParameter
    {
        public string Value { get; }

        public GremlinScope(string scopeName)
        {
            Value = scopeName;
        }

        public static GremlinScope Local => new GremlinScope("local");
    }
}