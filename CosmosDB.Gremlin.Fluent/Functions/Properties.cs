using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class PropertiesFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The properties()-step (map) extracts properties from an Element in the traversal stream
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="propertyKeys"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Properties(this GremlinQueryBuilder builder, params IGremlinParameter[] propertyKeys)
        {
            if (propertyKeys == null || !propertyKeys.Any())
                return builder.Add($"properties()");
            if (!propertyKeys.All(k => k.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Properties)} only accepts {nameof(propertyKeys)} that resolve to strings");
            
            builder.AddArguments(propertyKeys.OfType<GremlinArgument>().ToArray());
            return builder.Add($"properties({propertyKeys.Expand()})");
        }
    }
}