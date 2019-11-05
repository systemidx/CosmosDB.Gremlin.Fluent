using System;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Exception when building query
    /// </summary>
    public class GremlinQueryBuilderException: Exception 
    {
        /// <inheritdoc />
        public GremlinQueryBuilderException(string message) : base(message) { }
    }
}