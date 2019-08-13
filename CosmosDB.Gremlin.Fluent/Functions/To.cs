using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ToFunction
    {
        /// <summary>
        /// The to()-step is not an actual step, but instead is a "step-modulator" similar to as() and by().
        /// If a step is able to accept traversals or strings then to() is the means by which they are added.
        /// The general pattern is step().to(). See <seealso cref="FromFunction.From(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/>.
        /// The list of steps that support to()-modulation are: simplePath(), cyclicPath(), path(), and addE().
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(To)} only accepts parameters that " +
                                                       $"resolve to strings and {parameter.TrueValue} does not");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"to({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// The to()-step is not an actual step, but instead is a "step-modulator" similar to as() and by().
        /// If a step is able to accept traversals or strings then to() is the means by which they are added.
        /// The general pattern is step().to(). See <seealso cref="FromFunction.From(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,string)"/>.
        /// The list of steps that support to()-modulation are: simplePath(), cyclicPath(), path(), and addE().
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.To((GremlinParameter)parameter);
        }

        /// <summary>
        /// The to()-step is not an actual step, but instead is a "step-modulator" similar to as() and by().
        /// If a step is able to accept traversals or strings then to() is the means by which they are added.
        /// The general pattern is step().to(). See <seealso cref="FromFunction.From(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.GremlinQueryBuilder)"/>.
        /// The list of steps that support to()-modulation are: simplePath(), cyclicPath(), path(), and addE().
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="GremlinQueryBuilderException"></exception>
        public static GremlinQueryBuilder To(this GremlinQueryBuilder builder, GremlinQueryBuilder func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            
            builder.AddArguments(func.GremlinArguments);
            return builder.Add($"to({func.Query})");
        }
    }
}
