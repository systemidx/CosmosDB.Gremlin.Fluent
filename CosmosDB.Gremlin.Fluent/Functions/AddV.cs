using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddVFunction
    {
        /// <summary>
        /// The addV()-step is used to add vertices to the graph (map/sideEffect). For every incoming object, a vertex is created
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">Optional vertex label that if supplied must be a string. If not supplied will be an auto generated GUID</param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder AddV(this GremlinQueryBuilder builder, IGremlinParameter parameter = null)
        {
            if (parameter == null)
            {
                return builder.Add($"addV()");
            }
            else
            {
                if (!(parameter.TrueValue is string))
                    throw new GremlinQueryBuilderException($"{nameof(AddV)} only accepts string parameters and {parameter.TrueValue} is not");

                builder.AddArgument(parameter as GremlinArgument);
                return builder.Add($"addV({parameter.QueryStringValue})");
            }
        }

        /// <summary>
        /// The addV()-step is used to add vertices to the graph (map/sideEffect). For every incoming object, a vertex is created
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inner">Graph traversal returning a string label</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder AddV(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                throw new ArgumentNullException(nameof(inner));

            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"addV({inner.Query})");
        }

        /// <summary>
        /// Create a new graph vertex
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">Optional vertex label that if supplied must be a string. If not supplied will be an auto generated GUID</param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder AddV(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.AddV((IGremlinParameter)parameter);
        }
    }
}
