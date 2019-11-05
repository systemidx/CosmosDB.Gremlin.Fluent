using CosmosDB.Gremlin.Fluent.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class AddVFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxForStringParametersAndTraversals()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.AddV(new GremlinParameter("myparam"));
            builder.AddV(new GremlinQueryBuilder().G().V("someId").Values((GremlinParameter)"label"));

            Assert.Equal("addV('myparam').addV(g.V('someId').values('label'))", builder.Query);
        }

        [Fact]
        public void GenerateCorrectSyntaxForParameterlessInvocation()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.AddV();
            
            Assert.Equal("addV()", builder.Query);
        }

        [Fact]
        public void RejectNonStringParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<GremlinQueryBuilderException>(() => builder.AddV(new GremlinParameter(42)));
            Assert.Throws<GremlinQueryBuilderException>(() => builder.AddV(new GremlinParameter(false)));

        }

        [Fact]
        public void SupportArguments()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.AddV(new GremlinArgument("argumentName", "argumentValue"));

            Assert.Equal("addV(argumentName)", builder.Query);
            Assert.Single(builder.Arguments);
        }
    }
}
