using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasNotFunction
    {
        /// <summary>
        /// Remove the traverser if its element has a value for the key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, IGremlinParameter key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (!(key.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(HasNot)} only accepts {nameof(key)} that resolves to string " +
                    $"and {key.TrueValue} does not");
            
            builder.AddArgument(key as GremlinArgument);
            return builder.Add($"hasNot({key.QueryStringValue})");
        }
        
        /// <summary>
        /// Remove the traverser if its element has a value for the key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder HasNot(this GremlinQueryBuilder builder, string key)
        {
            // for implicit conversion operators
            return builder.HasNot((GremlinParameter)key);
        }
    }
}