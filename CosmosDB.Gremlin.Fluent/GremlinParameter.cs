namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// General gremlin query builder parameter. Represents constant value written directly to the query text
    /// </summary>
    public class GremlinParameter : IGremlinParameter
    {
        /// <inheritdoc />
        public virtual string QueryStringValue { get; }

        /// <inheritdoc />
        public virtual object TrueValue { get; }

        /// <summary>
        /// Create a string parameter. Single quotes ' will be stripped!
        /// If these are necessary, use <seealso cref="GremlinArgument"/> instead.
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(string parameter)
        {
            QueryStringValue = $"'{Sanitize(parameter)}'";
            TrueValue = parameter;
        }

        /// <summary>
        /// Create an integer parameter
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(int parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }
        
        /// <summary>
        /// Create a long parameter
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(long parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }
        
        /// <summary>
        /// Create a double parameter
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(double parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }

        /// <summary>
        /// Create a single/float parameter
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(float parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }

        /// <summary>
        /// Create a boolean parameter
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(bool parameter)
        {
            QueryStringValue = $"{parameter}".ToLowerInvariant();
            TrueValue = parameter;
        }

        /// <summary>
        /// Create a byte parameter
        /// </summary>
        /// <param name="parameter"></param>
        public GremlinParameter(byte parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }

#pragma warning disable 1591
        public static implicit operator GremlinParameter(int parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(string parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(bool parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(long parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(double parameter)
        {
            return new GremlinParameter(parameter);
        }

        public static implicit operator GremlinParameter(float parameter)
        {
            return new GremlinParameter(parameter);
        }

        public static implicit operator GremlinParameter(byte parameter)
        {
            return new GremlinParameter(parameter);
        }
#pragma warning restore 1591

        /// <summary>
        /// Remove single quotes from supplied string
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="GremlinParameterException"></exception>
        protected string Sanitize(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new GremlinParameterException($"{nameof(parameter)} cannot be null");

            return parameter.Replace("'", string.Empty);
        }
    }
}
