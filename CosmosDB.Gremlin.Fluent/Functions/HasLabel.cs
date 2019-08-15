using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class HasLabelFunction
    {
        /// <summary>
        /// Remove the traverser if its element does not have any of the labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, GremlinQueryBuilder predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            builder.AddArguments(predicate.GremlinArguments);
            return builder.Add($"hasLabel({predicate.Query})");
        }
        
        /// <summary>
        /// Remove the traverser if its element does not have any of the labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, params IGremlinParameter[] values)
        {
            if (values == null || !values.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(HasLabel)} requires one or more arguments to be supplied in {nameof(values)}");
            if (!values.All(v => v.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(HasLabel)} only accepts arguments that resolve to strings in {nameof(values)}");
            
            builder.AddArguments(values.OfType<GremlinArgument>().ToArray());
            return builder.Add($"hasLabel({values.Expand()})");
        }
        
        /// <summary>
        /// Remove the traverser if its element does not have any of the labels
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder HasLabel(this GremlinQueryBuilder builder, string label)
        {
            // for implicit conversion operators with common single label scenario
            return builder.HasLabel((GremlinParameter)label);
        }
    }
}
