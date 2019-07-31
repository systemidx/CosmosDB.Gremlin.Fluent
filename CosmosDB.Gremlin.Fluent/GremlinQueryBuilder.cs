using System.Collections.Generic;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinQueryBuilder
    {
        public string Query { get; private set; } = "";

        public Dictionary<string, object> Arguments
        {
            get { return GremlinArguments.ToDictionary(arg => arg.ArgumentName, arg => arg.ArgumentValue); }
        }

        protected internal List<GremlinArgument> GremlinArguments { get; set; } = new List<GremlinArgument>();

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

        protected internal void AddArguments(IReadOnlyCollection<GremlinArgument> arguments)
        {
            foreach (var gremlinArgument in arguments)
            {
                AddArgument(gremlinArgument);
            }
        }

        public GremlinQueryBuilder Add(string value)
        {
            if (Query.Length > 0)
                Query += ".";

            Query += value;

            return this;
        }
    }
}
