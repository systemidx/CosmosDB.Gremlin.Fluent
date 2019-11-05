using CosmosDB.Gremlin.Fluent.Functions;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Special comparator parameter. Used by <seealso cref="ByFunction.By(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter[])"/>
    /// </summary>
    public class GremlinComparator : IGremlinParameter
    {
        /// <inheritdoc />
        public virtual string QueryStringValue { get; }

        /// <inheritdoc />
        public virtual object TrueValue => QueryStringValue;

        private GremlinComparator(string tokenValue)
        {
            QueryStringValue = tokenValue;
        }

        /// <summary>
        /// Incremental (ascending) sorting directive
        /// </summary>
        public static GremlinComparator Incr => new GremlinComparator("incr");
        
        /// <summary>
        /// Decremental (descending) sorting directive
        /// </summary>
        public static GremlinComparator Decr => new GremlinComparator("decr");
    }
}