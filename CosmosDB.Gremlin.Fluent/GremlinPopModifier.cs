using CosmosDB.Gremlin.Fluent.Functions;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Apache Pop modifier. Used by <seealso cref="SelectFunction.Select(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter[])"/>
    /// </summary>
    public class GremlinPopModifier
    {
        /// <summary>
        /// String representation for the purposes of building the query string
        /// </summary>
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