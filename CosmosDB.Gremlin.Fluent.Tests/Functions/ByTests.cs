using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class ByTests
    {
        [Fact]
        public void GeneratesCorrectSyntaxWithParameter()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.By(new GremlinParameter("myparam"));

            Assert.Equal("by('myparam')", builder.Query);
        }

        [Fact]
        public void GeneratesCorrectSyntaxWithFunction()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.By(new GremlinQueryBuilder().AddE(new GremlinParameter("myparam")));

            Assert.Equal("by(addE('myparam'))", builder.Query);
        }
    }
}
