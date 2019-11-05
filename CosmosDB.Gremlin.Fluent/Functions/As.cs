using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class AsFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The as()-step is not a real step, but a "step modulator" similar to by().
        /// With as(), it is possible to provide a label to the step that can later be accessed by steps and
        /// data structures that make use of such labels — e.g., select(), match(), and path()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder As(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(As)} requires at least one string parameter in {nameof(parameters)}");
            if (!parameters.All(p => p.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(As)} only accepts string parameters");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"as({parameters.Expand()})");
        }
        
        /// <summary>
        /// The as()-step is not a real step, but a "step modulator" similar to by().
        /// With as(), it is possible to provide a label to the step that can later be accessed by steps and
        /// data structures that make use of such labels — e.g., select(), match(), and path()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder As(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators
            return builder.As((IGremlinParameter)parameter);
        }
    }
}
