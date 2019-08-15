using System;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Parameter to gremlin query builder. Represents argument name and value, to separate data from the query itself.
    /// </summary>
    public class GremlinArgument : IGremlinParameter
    {
        /// <inheritdoc />
        public virtual string QueryStringValue => ArgumentName;

        /// <inheritdoc />
        public virtual object TrueValue => ArgumentValue;

        /// <summary>
        /// Value of the argument
        /// </summary>
        public object ArgumentValue { get; }
        
        /// <summary>
        /// Name of the argument
        /// </summary>
        public string ArgumentName { get; }
        
        /// <summary>
        /// Construct a new argument from the supplied name and value
        /// </summary>
        /// <param name="argumentName"></param>
        /// <param name="argumentValue"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinParameterException"></exception>
        public GremlinArgument(string argumentName, object argumentValue)
        {
            if (argumentName == null)
                throw new ArgumentNullException(nameof(argumentName));
            if (string.IsNullOrWhiteSpace(argumentName))
                throw new GremlinParameterException("Argument name cannot be blank");

            ArgumentName = argumentName;
            ArgumentValue = argumentValue ?? throw new ArgumentNullException(nameof(argumentValue));
        }
    }
}