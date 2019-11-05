using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class FromFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The from()-step is not an actual step, but instead is a "step-modulator" similar to as() and by().
        /// If a step is able to accept traversals or strings then from() is the means by which they are added.
        /// The general pattern is step().from(). See <seealso cref="ToFunction.To(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/>.
        /// The list of steps that support from()-modulation are: simplePath(), cyclicPath(), path(), and addE()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder From(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(From)} only accepts parameters that " +
                                                       $"resolve to strings and {parameter.TrueValue} does not");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"from({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// The from()-step is not an actual step, but instead is a "step-modulator" similar to as() and by().
        /// If a step is able to accept traversals or strings then from() is the means by which they are added.
        /// The general pattern is step().from(). See <seealso cref="ToFunction.To(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/>.
        /// The list of steps that support from()-modulation are: simplePath(), cyclicPath(), path(), and addE()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder From(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.From((GremlinParameter)parameter);
        }

        /// <summary>
        /// The from()-step is not an actual step, but instead is a "step-modulator" similar to as() and by().
        /// If a step is able to accept traversals or strings then from() is the means by which they are added.
        /// The general pattern is step().from(). See <seealso cref="ToFunction.To(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/>.
        /// The list of steps that support from()-modulation are: simplePath(), cyclicPath(), path(), and addE()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder From(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            
            builder.AddArguments(func.GremlinArguments);
            return builder.Add($"from({func.Query})");
        }
    }
}