using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class TailFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The tail()-step is analogous to limit()-step, except that it emits the last n-objects
        /// instead of the first n-objects
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, IGremlinParameter parameter = null)
        {
            if (parameter == null)
                return builder.Add("tail()");
            
            if (!parameter.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tail)} only supports numeric parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"tail({parameter.QueryStringValue})");
        }

        /// <summary>
        /// The tail()-step is analogous to limit()-step, except that it emits the last n-objects
        /// instead of the first n-objects
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
        {
            if (scope == null)
                throw new ArgumentNullException(nameof(scope));

            if (parameter == null)
                return builder.Add($"tail({scope.QueryStringValue})");
            
            if (!parameter.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Tail)} only supports numeric parameters and scope and '{parameter.TrueValue}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"tail({scope.QueryStringValue},{parameter.QueryStringValue})");
        }

        /// <summary>
        /// The tail()-step is analogous to limit()-step, except that it emits the last n-objects
        /// instead of the first n-objects
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, GremlinScope scope,
            long parameter)
        {
            // shortcut overload for common scenario
            return builder.Tail(scope, (GremlinParameter) parameter);
        }
           
        /// <summary>
        /// The tail()-step is analogous to limit()-step, except that it emits the last n-objects
        /// instead of the first n-objects
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Tail(this GremlinQueryBuilder builder, long parameter)
        {
            // shortcut overload for common scenario
            return builder.Tail((GremlinParameter) parameter);
        }
    }
}