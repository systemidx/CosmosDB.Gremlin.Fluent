using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class BarrierFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxForParameterlessInvocation()
        {
            var builder = new GremlinQueryBuilder();
            builder.Barrier();
            
            Assert.Equal("barrier()", builder.Query);
        }
        
        [Fact]
        public void GenerateCorrectSyntaxWithIntegerParameter()
        {
            var builder = new GremlinQueryBuilder();
            builder.Barrier((GremlinParameter) 5);

            Assert.Equal("barrier(5)", builder.Query);
        }

        [Fact]
        public void HandleArguments()
        {
            var builder = new GremlinQueryBuilder();
            builder.Barrier(new GremlinArgument("five", 5));

            Assert.Equal("barrier(five)", builder.Query);
            Assert.Single(builder.Arguments);
        }

    }
}