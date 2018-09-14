namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BothFunction
    {
        public static GremlinQueryBuilder Both(this GremlinQueryBuilder builder, params GremlinParameter[] parameters)
        {
            return builder.Add($"both({parameters.Expand()})");
        }
    }
}
