using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class StartingWithFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// String predicate that tests incoming string to see if it starts with specified argument string value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder StartingWith(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!(parameter.TrueValue is string))
                throw new GremlinQueryBuilderException($"{nameof(StartingWith)} requires {nameof(parameter)} to " +
                                                       $"be a string and {parameter.TrueValue} does not appear to be");
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"startingWith({parameter.QueryStringValue})");
        }
        
        /// <summary>
        /// String predicate that tests incoming string to see if it starts with specified argument string value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static GremlinQueryBuilder StartingWith(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.StartingWith((GremlinParameter)parameter);
        }
    }
}