using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class HasIdFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Remove the traverser if its element does not have any of the ids
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, GremlinQueryBuilder predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            builder.AddArguments(predicate.GremlinArguments);
            return builder.Add($"hasId({predicate.Query})");
        }
        
        /// <summary>
        /// Remove the traverser if its element does not have any of the ids
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException($"{nameof(HasId)} requires at least one parameter in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"hasId({parameters.Expand()})");
        }
    
        /// <summary>
        /// Remove the traverser if its element does not have any of the ids
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder HasId(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            // for implicit conversion operators with common single id use
            return builder.HasId((IGremlinParameter)parameter);
        }
    }
}