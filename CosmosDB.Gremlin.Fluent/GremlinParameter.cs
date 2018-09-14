namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinParameter
    {
        public string Value { get; }

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

        private string Sanitize(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new GremlinParameterException();

            return parameter.Replace("'", string.Empty);
        }
    }
}
