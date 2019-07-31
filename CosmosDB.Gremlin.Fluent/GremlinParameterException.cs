using System;

namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinParameterException : Exception
    {
        public GremlinParameterException(string message) : base(message) { }
    }
}