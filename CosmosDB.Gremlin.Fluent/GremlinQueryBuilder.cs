using System.Collections.Generic;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Main class for building gremlin queries.
    /// Represents a single query of a single traversal/predicate parameter for another query builder
    /// </summary>
    public class GremlinQueryBuilder
    {
        /// <summary>
        /// Resultant text query string
        /// </summary>
        public string Query { get; private set; } = "";

        /// <summary>
        /// Query arguments as consumed by Gremlin.NET client
        /// </summary>
        public Dictionary<string, object> Arguments
        {
            get { return GremlinArguments.ToDictionary(arg => arg.ArgumentName, arg => arg.ArgumentValue); }
        }

        /// <summary>
        /// All gremlin arguments currently carried by this builder
        /// </summary>
        protected internal List<GremlinArgument> GremlinArguments { get; set; } = new List<GremlinArgument>();

        /// <summary>
        /// Start a new blank builder
        /// </summary>
        public GremlinQueryBuilder()
        {
            
        }

        /// <summary>
        /// Special constructor for initialising builder from a single parameter.
        /// Useful for complex chaining, e.g. has('price', between(10, 99)) etc.
        /// </summary>
        /// <param name="parameter">Gremlin parameter to initialise the builder with</param>
        public GremlinQueryBuilder(IGremlinParameter parameter)
        {
            AddArgument(parameter as GremlinArgument);
            Add(parameter.QueryStringValue);
        }

        /// <summary>
        /// Add argument to this builder. Handles duplicates.
        /// </summary>
        /// <param name="argument"></param>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        protected internal void AddArgument(GremlinArgument argument)
        {
            // we accept null arguments to minimise boilerplate
            if (argument == null)
                return;
            
            if (GremlinArguments.Any(arg =>
                    arg.ArgumentName == argument.ArgumentName &&
                    arg.ArgumentValue != argument.ArgumentValue))
            {
                throw new GremlinQueryBuilderException("Multiple values for the same argument are not supported");
            }

            if (GremlinArguments.All(arg => arg.ArgumentName != argument.ArgumentName))
            {
                GremlinArguments.Add(argument);    
            }
        }

        /// <summary>
        /// Add multiple arguments to the builder. Handles deduplication natively.
        /// </summary>
        /// <param name="arguments"></param>
        protected internal void AddArguments(IReadOnlyCollection<GremlinArgument> arguments)
        {
            foreach (var gremlinArgument in arguments)
            {
                AddArgument(gremlinArgument);
            }
        }

        /// <summary>
        /// Append raw text string to the end of the current builder, separating each addition with a period.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public GremlinQueryBuilder Add(string value)
        {
            if (Query.Length > 0)
                Query += ".";

            Query += value;

            return this;
        }
        
    }
}
