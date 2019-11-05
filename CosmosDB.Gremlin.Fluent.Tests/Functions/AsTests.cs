using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class AsFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxForStringParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.As("a");
            builder.As((GremlinParameter) "b", (GremlinParameter) "c");
            
            Assert.Equal("as('a').as('b','c')", builder.Query);
        }
        
        [Fact]
        public void RejectNonStringParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<GremlinQueryBuilderException>(() => builder.As(new GremlinParameter(42)));
            Assert.Throws<GremlinQueryBuilderException>(() => builder.As(new GremlinParameter(false)));
        }

        [Fact]
        public void RequireAtLeastOneParameter()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<GremlinQueryBuilderException>(() => builder.As());
        }

        [Fact]
        public void SupportArguments()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.As(new GremlinArgument("argumentName", "argumentValue"));

            Assert.Equal("as(argumentName)", builder.Query);
            Assert.Single(builder.Arguments);
        }
    }
}