using CosmosDB.Gremlin.Fluent.Functions;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Representation of TinkerPop cardinality modifier. Used by <seealso cref="PropertyFunction.Property(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter[])"/>
    /// </summary>
    public class GremlinCardinality
    {
        /// <summary>
        /// Parameter to gremlin query builder function
        /// </summary>
        public string QueryStringValue { get; }

        private GremlinCardinality(string value)
        {
            QueryStringValue = value;
        }
        
        /// <summary>
        /// TinkerPop single
        /// </summary>
        public static GremlinCardinality Single => new GremlinCardinality("single");
        
        /// <summary>
        /// TinkerPop set
        /// </summary>
        public static GremlinCardinality Set => new GremlinCardinality("set");
        
        /// <summary>
        /// TinkerPop list
        /// </summary>
        public static GremlinCardinality List => new GremlinCardinality("list");
    }
}