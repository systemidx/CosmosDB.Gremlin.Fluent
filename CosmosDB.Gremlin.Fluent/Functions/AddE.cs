using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddEFunction
    {
        /// <summary>
        /// Create a new graph edge with the specified label
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">Edge label, must resolve to a string</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder AddE(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(AddE)} only accepts string parameters and {parameter.TrueValue} is not");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"addE({parameter.QueryStringValue})");
        }

        /// <summary>
        /// Create a new graph edge with label determined from the supplied traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inner">Graph traversal returning a string for edge label</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder AddE(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                throw new ArgumentNullException(nameof(inner));

            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"addE({inner.Query})");
        }

        /// <summary>
        /// Create a new graph edge with the specified label
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">Edge label, must resolve to a string</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder AddE(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.AddE((IGremlinParameter)parameter);
        }
    }
}
