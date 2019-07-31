namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinParameter : IGremlinParameter
    {
        public virtual string Value { get; }

        public GremlinParameter(string parameter)
        {
            Value = $"'{Sanitize(parameter)}'";
        }

        public GremlinParameter(int parameter)
        {
            Value = $"{parameter}";
        }

        public GremlinParameter(bool parameter)
        {
            Value = $"{parameter}".ToLowerInvariant();
        }

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
        
        protected virtual string Sanitize(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new GremlinParameterException($"{nameof(parameter)} cannot be null");

            return parameter.Replace("'", string.Empty);
        }
    }
}
