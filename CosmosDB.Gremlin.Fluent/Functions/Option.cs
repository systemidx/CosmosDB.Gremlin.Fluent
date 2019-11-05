using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class OptionFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// An option for the choose() function (since CosmosDB doesn't support branch())
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="optionValue">Value to test against</param>
        /// <param name="traversal">Traversal for successful test</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Choose(this GremlinQueryBuilder builder, IGremlinParameter optionValue, GremlinQueryBuilder traversal)
        {
            if (optionValue == null)
                throw new ArgumentNullException(nameof(optionValue));
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));
            
            builder.AddArguments(traversal.GremlinArguments);
            builder.AddArgument(optionValue as GremlinArgument);
            return builder.Add($"option({optionValue.QueryStringValue},{traversal.Query})");
        }
        
        /// <summary>
        /// An option for the choose() function (since CosmosDB doesn't support branch())
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal">Traversal for successful test</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Choose(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));
            
            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"option({traversal.Query})");
        }
    }
}