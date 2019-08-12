using CosmosDB.Gremlin.Fluent.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class AggregateFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxForStringParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.Aggregate(new GremlinParameter("myparam"));
            
            Assert.Equal("aggregate('myparam')", builder.Query);
        }

        [Fact]
        public void RejectNonStringParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<GremlinQueryBuilderException>(() => builder.Aggregate(new GremlinParameter(42)));
            Assert.Throws<GremlinQueryBuilderException>(() => builder.Aggregate(new GremlinParameter(false)));
        }

        [Fact]
        public void AcceptScope()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.Aggregate(GremlinScope.Local, new GremlinParameter("myparam"));
            
            Assert.Equal("aggregate(local,'myparam')", builder.Query);
        }

        [Fact]
        public void SupportArguments()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.Aggregate(new GremlinArgument("argumentName", "argumentValue"));

            Assert.Equal("aggregate(argumentName)", builder.Query);
            Assert.Single(builder.Arguments);
        }
    }
}
