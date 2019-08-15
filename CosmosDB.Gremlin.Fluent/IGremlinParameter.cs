using System.Collections.Generic;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Parameter to gremlin query builder function
    /// </summary>
    public interface IGremlinParameter
    {
        /// <summary>
        /// String representation for the purposes of building the query string
        /// </summary>
        string QueryStringValue { get; }
        
        /// <summary>
        /// Value used for validation. 
        /// </summary>
        object TrueValue { get; }
    }
}