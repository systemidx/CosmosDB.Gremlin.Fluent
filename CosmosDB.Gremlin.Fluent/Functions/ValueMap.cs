using System;
using System.Linq;

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
        /// <param name="parameters">First parameter can be a boolean true to return id and label properties.
        ///                         Subsequent ones, if specified, will limit the response to just these properties.
        ///                         If omitted, all properties are returned</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder ValueMap(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            // this function can only take true or false
            if (parameters.Any(p => p == null))
                throw new ArgumentException("Null parameters are not allowed");

            // first parameter can be string or bool
            if (parameters.Any() && !(parameters.First().TrueValue is bool) &&
                !(bool.TryParse(parameters.First().TrueValue.ToString(), out _)) &&
                !(parameters.First().TrueValue is string))
            {
                throw new GremlinQueryBuilderException(
                    $"{nameof(ValueMap)} only supports boolean or string parameters as the first parameter and '{parameters.First().TrueValue}' does not appear to be");
            }

            // subsequent parameters can only be strings
            if (parameters.Length > 1 && parameters.Skip(1).Any(p => !(p.TrueValue is string)))
            {
                throw new GremlinQueryBuilderException(
                    $"{nameof(ValueMap)} only supports strings as parameters other than the initial one that can also be a boolean");
            }

            if (parameters.Any(p => p.TrueValue is string s && (s == "id" || s == "label")))
            {
                throw new GremlinQueryBuilderException(
                    $"Property names 'id' and 'label' are not allowed. " +
                    $"If these are required, pass boolean 'true' as the first parameter to {nameof(ValueMap)}, " +
                    $"e.g. ValueMap(true) or ValueMap(true, \"PropertyName\"");
            }

            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"valueMap({parameters.Expand()})");
        }

        /// <summary>
        /// The valueMap()-step yields a Map representation of the properties of an element.
        /// It is important to note that the map of a vertex maintains a list of values for each key.
        /// The map of an edge or vertex-property represents a single property (not a list).
        /// The reason is that vertices in TinkerPop leverage vertex properties which support multiple values per key.
        /// CosmosDb implementation doesn't support modulating it with .by(unfold())!
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="includeIdAndLabel">Boolean true to return id and label properties</param>
        /// <param name="properties">If specified, only these properties will be included. Cannot contain 'id' and 'label'</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder ValueMap(this GremlinQueryBuilder builder, bool includeIdAndLabel, params string[] properties)
        {
            // overload for simplifying usage
            var parameters =
                new IGremlinParameter[] {new GremlinParameter(includeIdAndLabel)}.Concat(
                    (properties ?? new string[0]).Select(p => new GremlinParameter(p)));

            return builder.ValueMap(parameters.ToArray());
        }

        /// <summary>
        /// The valueMap()-step yields a Map representation of the properties of an element.
        /// It is important to note that the map of a vertex maintains a list of values for each key.
        /// The map of an edge or vertex-property represents a single property (not a list).
        /// The reason is that vertices in TinkerPop leverage vertex properties which support multiple values per key.
        /// CosmosDb implementation doesn't support modulating it with .by(unfold())!
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="properties">If specified, only these properties will be included. Cannot contain 'id' and 'label'</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder ValueMap(this GremlinQueryBuilder builder, string[] properties)
        {
            // overload for simplifying usage
            var parameters =
                (properties ?? new string[0]).Select(p => (IGremlinParameter)new GremlinParameter(p));

            return builder.ValueMap(parameters.ToArray());
        }
    }
}