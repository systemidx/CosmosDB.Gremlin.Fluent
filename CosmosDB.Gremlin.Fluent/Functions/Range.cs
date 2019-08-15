using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class RangeFunction
    {
        /// <summary>
        /// As traversers propagate through the traversal, it is possible to only allow a certain number of them
        /// to pass through with range()-step (filter). When the low-end of the range is not met, objects are continued
        /// to be iterated. When within the low (inclusive) and high (exclusive) range, traversers are emitted.
        /// When above the high range, the traversal breaks out of iteration.
        /// Finally, the use of -1 on the high range will emit remaining traversers after the low range begins
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!start.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{start.TrueValue}' does not appear to conform to this");
            if (!end.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{end.TrueValue}' does not appear to conform to this");
            
            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"range({start.QueryStringValue},{end.QueryStringValue})");
        }

        /// <summary>
        /// As traversers propagate through the traversal, it is possible to only allow a certain number of them
        /// to pass through with range()-step (filter). When the low-end of the range is not met, objects are continued
        /// to be iterated. When within the low (inclusive) and high (exclusive) range, traversers are emitted.
        /// When above the high range, the traversal breaks out of iteration.
        /// Finally, the use of -1 on the high range will emit remaining traversers after the low range begins
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!start.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{start.TrueValue}' does not appear to conform to this");
            if (!end.IsNumber(true))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Range)} only supports numeric parameters and scope and '{end.TrueValue}' does not appear to conform to this");

            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"range({scope.QueryStringValue},{start.QueryStringValue},{end.QueryStringValue})");
        }
        
        /// <summary>
        /// As traversers propagate through the traversal, it is possible to only allow a certain number of them
        /// to pass through with range()-step (filter). When the low-end of the range is not met, objects are continued
        /// to be iterated. When within the low (inclusive) and high (exclusive) range, traversers are emitted.
        /// When above the high range, the traversal breaks out of iteration.
        /// Finally, the use of -1 on the high range will emit remaining traversers after the low range begins
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, long start, long end)
        {
            // For implicit operators
            return builder.Range((GremlinParameter) start, (GremlinParameter) end);
        }

        /// <summary>
        /// As traversers propagate through the traversal, it is possible to only allow a certain number of them
        /// to pass through with range()-step (filter). When the low-end of the range is not met, objects are continued
        /// to be iterated. When within the low (inclusive) and high (exclusive) range, traversers are emitted.
        /// When above the high range, the traversal breaks out of iteration.
        /// Finally, the use of -1 on the high range will emit remaining traversers after the low range begins
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder Range(this GremlinQueryBuilder builder, GremlinScope scope, long start, long end)
        {
            // For implicit operators
            return builder.Range(scope, (GremlinParameter) start, (GremlinParameter) end);
        }

    }
}