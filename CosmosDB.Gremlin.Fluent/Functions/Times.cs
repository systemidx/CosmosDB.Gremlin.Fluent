using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class TimesFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// Limit iteration to specified number of times
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Times(this GremlinQueryBuilder builder, IGremlinParameter number)
        {
            if (number == null)
                throw new ArgumentNullException(nameof(number));
            if (!number.IsNumber(true))
                throw new GremlinQueryBuilderException($"{nameof(Times)} only accepts numeric arguments and " +
                                                       $"{number.TrueValue} does not appear to be");
            
            builder.AddArgument(number as GremlinArgument);
            return builder.Add($"times({number.QueryStringValue})");
        }
    }
}