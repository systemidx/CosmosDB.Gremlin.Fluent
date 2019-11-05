using CosmosDB.Gremlin.Fluent.Functions;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// TinkerPop Column modifier. Used by <seealso cref="SelectFunction.Select(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.GremlinColumnModifier)"/>
    /// </summary>
    public class GremlinColumnModifier
    {
        /// <summary>
        /// Parameter to gremlin query builder function
        /// </summary>
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