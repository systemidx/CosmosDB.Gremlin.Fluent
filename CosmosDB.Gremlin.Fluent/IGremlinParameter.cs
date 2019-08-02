using System.Collections.Generic;

namespace CosmosDB.Gremlin.Fluent
{
    public interface IGremlinParameter
    {
        string QueryStringValue { get; }
        
        /// <summary>
        /// Value used for validation. 
        /// </summary>
        object TrueValue { get; }
    }
}