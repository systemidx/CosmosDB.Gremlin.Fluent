using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class AddEdgeTests
    {
        [Fact]
        public void GeneratesCorrectSyntax()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.AddE(new GremlinParameter("myparam"));
            builder.AddE(new GremlinParameter(14));

            Assert.Equal("addE('myparam').addE(14)", builder.Query);
        }
    }
}
