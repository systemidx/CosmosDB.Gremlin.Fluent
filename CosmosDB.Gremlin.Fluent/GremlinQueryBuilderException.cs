using System;

namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinQueryBuilderException: Exception 
    {
        public GremlinQueryBuilderException(string message) : base(message) { }
    }
}