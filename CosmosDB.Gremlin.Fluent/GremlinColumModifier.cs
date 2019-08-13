namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinColumnModifier
    {
        public string QueryStringValue { get; }
        
        private GremlinColumnModifier(string value)
        {
            QueryStringValue = value;
        }
        
        /// <summary>
        /// The keys associated with the data structure
        /// </summary>
        public static GremlinColumnModifier Keys => new GremlinColumnModifier("keys");
        
        /// <summary>
        /// The values associated with the data structure
        /// </summary>
        public static GremlinColumnModifier Values => new GremlinColumnModifier("values");
    }
}