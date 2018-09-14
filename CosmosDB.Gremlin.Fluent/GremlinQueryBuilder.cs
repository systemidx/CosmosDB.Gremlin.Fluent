namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinQueryBuilder
    {
        public string Query { get; private set; } = "";
        
        public GremlinQueryBuilder Add(string value)
        {
            if (Query.Length > 0)
                Query += ".";

            Query += value;

            return this;
        }
    }
}
