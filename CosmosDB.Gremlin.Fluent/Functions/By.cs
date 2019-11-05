using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class ByFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The by()-step is not an actual step, but instead is a "step-modulator" similar to as() and option().
        /// If a step is able to accept traversals, functions, comparators, etc. then by()
        /// is the means by which they are added. The general pattern is step().by()…​by().
        /// Some steps can only accept one by() while others can take an arbitrary amount
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException($"{nameof(By)} requires at least one parameter in {nameof(parameters)}");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"by({parameters.Expand()})");
        }
        
        /// <summary>
        /// The by()-step is not an actual step, but instead is a "step-modulator" similar to as() and option().
        /// If a step is able to accept traversals, functions, comparators, etc. then by()
        /// is the means by which they are added. The general pattern is step().by()…​by().
        /// Some steps can only accept one by() while others can take an arbitrary amount
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversals"></param>
        /// <returns></returns>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder By(this GremlinQueryBuilder builder, params GremlinQueryBuilder[] traversals)
        {
            if (traversals == null || !traversals.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(By)} requires at least a single parameter in {nameof(traversals)}");
            
            builder.AddArguments(traversals.SelectMany(f => f.GremlinArguments).ToArray());
            return builder.Add($"by({traversals.Expand()})");
        }
    }
}
