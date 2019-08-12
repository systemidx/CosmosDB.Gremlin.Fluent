using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class AndFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxWithFunctions()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.And(new GremlinQueryBuilder().__().Out(new GremlinParameter("myparam")).HasId("test"),
                new GremlinQueryBuilder().__().Out().Has((GremlinParameter)"name", (GremlinParameter)"MyName"));

            Assert.Equal("and(__.out('myparam').hasId('test'),__.out().has('name','MyName'))", builder.Query);
        }

        [Fact]
        public void GenerateCorrectSyntaxWithInfixNotation()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.G().V().Out(new GremlinParameter("myparam")).HasId("test")
                .And()
                .Out().Has((GremlinParameter)"name", (GremlinParameter)"MyName");

            Assert.Equal("g.V().out('myparam').hasId('test').and().out().has('name','MyName')", builder.Query);
        }

        [Fact]
        public void HandleArguments()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.And(new GremlinQueryBuilder().__().Out(new GremlinArgument("myArgument1", "myparam"))
                .HasId(new GremlinArgument("testArgument", "test")),
                new GremlinQueryBuilder().__().Out()
                .Has((GremlinParameter)"name", new GremlinArgument("nameArgument","MyName")));

            Assert.Equal("and(__.out(myArgument1).hasId(testArgument),__.out().has('name',nameArgument))", builder.Query);
            Assert.Equal(3, builder.Arguments.Count);
        }
    }
}
