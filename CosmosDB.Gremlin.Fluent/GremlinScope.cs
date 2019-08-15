namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Representation of TinkerPop Scope.
    /// </summary>
    public class GremlinScope
    {
        /// <summary>
        /// String representation for the purposes of building the query string
        /// </summary>
        public string QueryStringValue { get; }
        
        private GremlinScope(string scopeName)
        {
            QueryStringValue = scopeName;
        }

        /// <summary>
        /// Informs the step to operate on the current object in the step
        /// </summary>
        public static GremlinScope Local => new GremlinScope("local");
        
        /// <summary>
        /// Informs the step to operate on the entire traversal
        /// </summary>
        public static GremlinScope Global => new GremlinScope("global");
    }
}