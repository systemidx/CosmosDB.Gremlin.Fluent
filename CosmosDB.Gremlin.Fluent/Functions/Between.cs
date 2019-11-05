using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class BetweenFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Predicate that checks if the incoming number is greater than or equal
        /// to the first provided number and less than the second
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Between(this GremlinQueryBuilder builder, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!start.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Between)} only supports numeric parameters and '{start.TrueValue}' does not appear to conform to this");
            if (!end.IsNumber())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Between)} only supports numeric parameters and '{end.TrueValue}' does not appear to conform to this");

            
            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"between({start.QueryStringValue},{end.QueryStringValue})");
        }
        
        /// <summary>
        /// Predicate that checks if the incoming number is greater than or equal
        /// to the first provided number and less than the second
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Between(this GremlinQueryBuilder builder, GremlinParameter start, GremlinParameter end)
        {
            // for implicit conversion operators
            return builder.Between((IGremlinParameter)start,(IGremlinParameter)end);
        }
    }
}