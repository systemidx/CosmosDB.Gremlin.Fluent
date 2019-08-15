using System;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// A validation exception with Gremlin query parameter
    /// </summary>
    public class GremlinParameterException : Exception
    {
        /// <inheritdoc />
        public GremlinParameterException(string message) : base(message) { }
    }
}