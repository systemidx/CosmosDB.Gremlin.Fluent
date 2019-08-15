namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinCardinality
    {
        public string QueryStringValue { get; }

        private GremlinCardinality(string value)
        {
            QueryStringValue = value;
        }
        
        public static GremlinCardinality Single => new GremlinCardinality("single");
        public static GremlinCardinality Set => new GremlinCardinality("set");
        public static GremlinCardinality List => new GremlinCardinality("list");
    }
}