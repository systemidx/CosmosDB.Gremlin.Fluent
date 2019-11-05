using CosmosDB.Gremlin.Fluent.Functions;
using System;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class __FunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntax()
        {
            // Arrange
            GremlinQueryBuilder builder = new GremlinQueryBuilder();

            // Act
            var result = builder.__();

            // Assert
            Assert.Equal("__", builder.Query);
        }
    }
}
