using System;
using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class SelectFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// There are two general ways to use select()-step.
        /// Select labeled steps within a path (as defined by as() in a traversal).
        /// Select objects out of a Map&lt;String,Object&gt; flow (i.e. a sub-map).
        /// When the set of keys or values (i.e. columns) of a path or map are needed, use select(keys)
        /// and select(values), respectively. select() can also accept a traversal that emits a key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, params IGremlinParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new GremlinQueryBuilderException(
                    $"{nameof(Select)} requires one or more parameters in {parameters}");
            if (!parameters.All(p => p.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(Select)} only accepts string parameters");
            
            builder.AddArguments(parameters.OfType<GremlinArgument>().ToArray());
            return builder.Add($"select({parameters.Expand()})");
        }
        
        /// <summary>
        /// There are two general ways to use select()-step.
        /// Select labeled steps within a path (as defined by as() in a traversal).
        /// Select objects out of a Map&lt;String,Object&gt; flow (i.e. a sub-map).
        /// When the set of keys or values (i.e. columns) of a path or map are needed, use select(keys)
        /// and select(values), respectively. select() can also accept a traversal that emits a key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, GremlinColumnModifier columns)
        {
            if (columns == null)
                throw new ArgumentNullException(nameof(columns));

            return builder.Add($"select({columns.QueryStringValue})");
        }

        /// <summary>
        /// There are two general ways to use select()-step.
        /// Select labeled steps within a path (as defined by as() in a traversal).
        /// Select objects out of a Map&lt;String,Object&gt; flow (i.e. a sub-map).
        /// When the set of keys or values (i.e. columns) of a path or map are needed, use select(keys)
        /// and select(values), respectively. select() can also accept a traversal that emits a key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="pop"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, GremlinPopModifier pop, IGremlinParameter label)
        {
            if (pop == null)
                throw new ArgumentNullException(nameof(pop));
            if (label == null)
                throw new ArgumentNullException(nameof(label));
            if (!(label.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(Select)} only allows strings in " +
                                                       $"{nameof(label)} parameter and {label.TrueValue} " +
                                                       $"does not appear to be");

            builder.AddArgument(label as GremlinArgument);
            return builder.Add($"select({pop.QueryStringValue},{label.QueryStringValue})");
        }
        
        /// <summary>
        /// There are two general ways to use select()-step.
        /// Select labeled steps within a path (as defined by as() in a traversal).
        /// Select objects out of a Map&lt;String,Object&gt; flow (i.e. a sub-map).
        /// When the set of keys or values (i.e. columns) of a path or map are needed, use select(keys)
        /// and select(values), respectively. select() can also accept a traversal that emits a key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));

            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"select({builder.Query})");
        }
        
        /// <summary>
        /// There are two general ways to use select()-step.
        /// Select labeled steps within a path (as defined by as() in a traversal).
        /// Select objects out of a Map&lt;String,Object&gt; flow (i.e. a sub-map).
        /// When the set of keys or values (i.e. columns) of a path or map are needed, use select(keys)
        /// and select(values), respectively. select() can also accept a traversal that emits a key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="pop"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, GremlinPopModifier pop, GremlinQueryBuilder traversal)
        {
            if (pop == null)
                throw new ArgumentNullException(nameof(pop));
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));

            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"select({pop.QueryStringValue},{builder.Query})");
        }
        
        /// <summary>
        /// There are two general ways to use select()-step.
        /// Select labeled steps within a path (as defined by as() in a traversal).
        /// Select objects out of a Map&lt;String,Object&gt; flow (i.e. a sub-map).
        /// When the set of keys or values (i.e. columns) of a path or map are needed, use select(keys)
        /// and select(values), respectively. select() can also accept a traversal that emits a key
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Select(this GremlinQueryBuilder builder, string label)
        {
            // overload for simple common usage scenario
            return builder.Select(new GremlinParameter(label));
        }
    }
}
