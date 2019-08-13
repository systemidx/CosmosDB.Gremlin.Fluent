using System;
using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class AddEFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxForStringParametersAndTraversals()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.AddE(new GremlinParameter("myparam"));
            builder.AddE(new GremlinQueryBuilder().G().V("someId").Values((GremlinParameter)"label"));

            Assert.Equal("addE('myparam').addE(g.V('someId').values('label'))", builder.Query);
        }
        
        [Fact]
        public void RejectNonStringParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<GremlinQueryBuilderException>(() => builder.AddE(new GremlinParameter(42)));
            Assert.Throws<GremlinQueryBuilderException>(() => builder.AddE(new GremlinParameter(false)));
        }

        [Fact]
        public void RequireParameterToBeNonNull()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.AddE((GremlinParameter) null));
        }
        
        [Fact]
        public void SupportArguments()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.AddE(new GremlinArgument("argumentName", "argumentValue"));

            Assert.Equal("addE(argumentName)", builder.Query);
            Assert.Single(builder.Arguments);
        }
    }
}
