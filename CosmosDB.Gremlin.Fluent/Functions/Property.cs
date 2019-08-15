using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class PropertyFunction
    {
        /// <summary>
        /// The property()-step is used to add properties to the elements of the graph (sideEffect).
        /// Unlike addV() and addE(), property() is a full sideEffect step in that it does not return the property
        /// it created, but the element that streamed into it. Moreover, if property() follows an addV() or addE(),
        /// then it is "folded" into the previous step to enable vertex and edge creation with
        /// all its properties in one creation operation
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Property(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Property)} requires at least one argument in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"property({parameters.Expand()})");
        }

        /// <summary>
        /// The property()-step is used to add properties to the elements of the graph (sideEffect).
        /// Unlike addV() and addE(), property() is a full sideEffect step in that it does not return the property
        /// it created, but the element that streamed into it. Moreover, if property() follows an addV() or addE(),
        /// then it is "folded" into the previous step to enable vertex and edge creation with
        /// all its properties in one creation operation
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="cardinality"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Property(this GremlinQueryBuilder builder, GremlinCardinality cardinality, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Property)} requires at least one argument in {nameof(parameters)}");
            if (cardinality == null)
                throw new ArgumentNullException(nameof(cardinality));
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"property({cardinality.QueryStringValue},{parameters.Expand()})");
        }
    }
}
