using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class ValueMapFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The valueMap()-step yields a Map representation of the properties of an element.
        /// It is important to note that the map of a vertex maintains a list of values for each key.
        /// The map of an edge or vertex-property represents a single property (not a list).
        /// The reason is that vertices in TinkerPop leverage vertex properties which support multiple values per key.
        /// CosmosDb implementation doesn't support modulating it with .by(unfold())!
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">Boolean true to return id and label properties</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder ValueMap(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            // this function can only take true or false
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is bool) && !(bool.TryParse(parameter.TrueValue.ToString(), out _)))
                throw new GremlinQueryBuilderException(
                    $"{nameof(ValueMap)} only supports boolean parameters and '{parameter.TrueValue}' does not appear to be");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"valueMap({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// The valueMap()-step yields a Map representation of the properties of an element.
        /// It is important to note that the map of a vertex maintains a list of values for each key.
        /// The map of an edge or vertex-property represents a single property (not a list).
        /// The reason is that vertices in TinkerPop leverage vertex properties which support multiple values per key.
        /// CosmosDb implementation doesn't support modulating it with .by(unfold())!
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">Boolean true to return id and label properties</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder ValueMap(this GremlinQueryBuilder builder, bool parameter)
        {
            // overload for simplifying usage
            return builder.ValueMap(new GremlinParameter(parameter));
        }
    }
}