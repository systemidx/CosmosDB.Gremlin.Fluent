using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class ByFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxWithParameter()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.By(new GremlinParameter("myparam"));

            Assert.Equal("by('myparam')", builder.Query);
        }

        [Fact]
        public void GenerateCorrectSyntaxWithFunction()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.By(new GremlinQueryBuilder().AddE(new GremlinParameter("myparam")));

            Assert.Equal("by(addE('myparam'))", builder.Query);
        }
    }
}
