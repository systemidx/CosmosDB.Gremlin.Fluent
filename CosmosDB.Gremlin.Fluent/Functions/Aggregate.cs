using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class AggregateFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The aggregate()-step (sideEffect) is used to aggregate all the objects at a particular point of traversal into a Collection.
        /// The step is uses Scope to help determine the aggregating behavior.
        /// For global scope this means that the step will use eager evaluation in that no objects continue on until all
        /// previous objects have been fully aggregated. The eager evaluation model is crucial in situations where
        /// everything at a particular point is required for future computation.
        /// By default, when the overload of aggregate() is called without a Scope, the default is global
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Aggregate(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Aggregate)} only accepts string parameters and {parameter.TrueValue} is not");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"aggregate({scope.QueryStringValue},{parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// The aggregate()-step (sideEffect) is used to aggregate all the objects at a particular point of traversal into a Collection.
        /// The step is uses Scope to help determine the aggregating behavior.
        /// For global scope this means that the step will use eager evaluation in that no objects continue on until all
        /// previous objects have been fully aggregated. The eager evaluation model is crucial in situations where
        /// everything at a particular point is required for future computation.
        /// By default, when the overload of aggregate() is called without a Scope, the default is global
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Aggregate(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Aggregate)} only accepts string parameters and {parameter.TrueValue} is not");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"aggregate({parameter.QueryStringValue})");
        }

        /// <summary>
        /// The aggregate()-step (sideEffect) is used to aggregate all the objects at a particular point of traversal into a Collection.
        /// The step is uses Scope to help determine the aggregating behavior.
        /// For global scope this means that the step will use eager evaluation in that no objects continue on until all
        /// previous objects have been fully aggregated. The eager evaluation model is crucial in situations where
        /// everything at a particular point is required for future computation.
        /// By default, when the overload of aggregate() is called without a Scope, the default is global
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Aggregate(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.Aggregate((GremlinParameter)parameter);
        }
    }
}
