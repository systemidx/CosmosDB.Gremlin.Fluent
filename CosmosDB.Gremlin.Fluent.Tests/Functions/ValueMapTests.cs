using System;
using System.Collections.Generic;
using System.Text;
using CosmosDB.Gremlin.Fluent.Functions;
using Xunit;

namespace CosmosDB.Gremlin.Fluent.Tests.Functions
{
    public class ValueMapFunctionShould
    {
        [Fact]
        public void GenerateCorrectSyntaxWithSingleBoolParameter()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.ValueMap(new GremlinParameter(true));

            Assert.Equal("valueMap(true)", builder.Query);
            Assert.Empty(builder.Arguments);
        }

        [Fact]
        public void GenerateCorrectSyntaxWithoutParameters()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.ValueMap();

            Assert.Equal("valueMap()", builder.Query);
            Assert.Empty(builder.Arguments);
        }

        [Fact]
        public void GenerateCorrectSyntaxWithArguments()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            builder.ValueMap(new GremlinArgument("bool", true), new GremlinArgument("propertyName", "prop"));

            Assert.Equal("valueMap(bool,propertyName)", builder.Query);
            Assert.Equal(2, builder.Arguments.Count);
        }

        [Fact]
        public void OnlyAcceptBoolAndStringAsFirstParameter()
        {
            GremlinQueryBuilder builder = new GremlinQueryBuilder();
            Assert.Throws<GremlinQueryBuilderException>(() => builder.ValueMap(new GremlinArgument("number", 15)));
            Assert.Throws<GremlinQueryBuilderException>(() =>
                builder.ValueMap((GremlinParameter) true, (GremlinParameter) true));
            Assert.Throws<GremlinQueryBuilderException>(() =>
                builder.ValueMap((GremlinParameter)true, (GremlinParameter)21));
            Assert.Throws<GremlinQueryBuilderException>(() =>
                builder.ValueMap((GremlinParameter) "propertyName", (GremlinParameter) true));
        }
    }
}
