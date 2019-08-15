using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class HasFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// It is possible to filter vertices, edges, and vertex properties based on their properties using has()-step (filter)
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="key"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Has(this GremlinQueryBuilder builder, IGremlinParameter key, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (!(key.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(key)} must always resolve to a string for property key and {key.TrueValue} does not");
            
            builder.AddArgument(key as GremlinArgument);
            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"has({key.QueryStringValue},{traversal.Query})");
        }

        /// <summary>
        /// It is possible to filter vertices, edges, and vertex properties based on their properties using has()-step (filter)
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="key"></param>
        /// <param name="value">Optional value to check for. If not supplied, checks for any value for the property referenced by <paramref name="key"/>/></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Has(this GremlinQueryBuilder builder, IGremlinParameter key, IGremlinParameter value = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (!(key.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(key)} must always resolve to a string for property key and {key.TrueValue} does not");

            builder.AddArgument(key as GremlinArgument);

            if (value == null)
            {
                return builder.Add($"has({key.QueryStringValue})");
            }
            else
            {
                builder.AddArgument(value as GremlinArgument);
                return builder.Add($"has({key.QueryStringValue},{value.QueryStringValue})");
            }
        }

        /// <summary>
        /// It is possible to filter vertices, edges, and vertex properties based on their properties using has()-step (filter)
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="label"></param>
        /// <param name="key"></param>
        /// <param name="value">Optional value to check for. If not supplied, checks for any value for the property referenced by <paramref name="key"/></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Has(this GremlinQueryBuilder builder, IGremlinParameter label, IGremlinParameter key, IGremlinParameter value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (!(key.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(key)} must always resolve to a string for property key and {key.TrueValue} does not");
            if (label == null)
                throw new ArgumentNullException(nameof(key));
            if (!(label.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(label)} must always resolve to a string for property key and {label.TrueValue} does not");
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            
            builder.AddArgument(key as GremlinArgument);
            builder.AddArgument(value as GremlinArgument);
            builder.AddArgument(label as GremlinArgument);

            return builder.Add($"has({label.QueryStringValue},{key.QueryStringValue},{value.QueryStringValue})");
        }
    }
}
