namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasLabelFunction
    {
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, GremlinParameter value)
        {
            if (value == null)
                throw new GremlinQueryBuilderException();

            return builder.Add($"hasLabel({value.Value})");
        }
    }
}
