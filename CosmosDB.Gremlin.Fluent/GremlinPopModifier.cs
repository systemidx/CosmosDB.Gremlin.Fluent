namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinPopModifier
    {
        public string QueryStringValue { get; }
        private GremlinPopModifier(string value)
        {
            QueryStringValue = value;
        }

        /// <summary>
        /// Get all the items and return them as a list
        /// </summary>
        public static GremlinPopModifier All => new GremlinPopModifier("all");
        
        /// <summary>
        /// First item in an ordered collection
        /// </summary>
        public static GremlinPopModifier First => new GremlinPopModifier("first");
        
        /// <summary>
        /// Last item in an ordered collection
        /// </summary>
        public static GremlinPopModifier Last => new GremlinPopModifier("last");
        
        /// <summary>
        /// Get the items as either a list (for multiple) or an object (for singles)
        /// </summary>
        public static GremlinPopModifier Mixed => new GremlinPopModifier("mixed");
    }
}