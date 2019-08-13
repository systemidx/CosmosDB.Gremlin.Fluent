using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class UntilFunction
    {
        /// <summary>
        /// The until-step is not an actual step, but is instead a step modulator for repeat().
        /// If until() comes after repeat() it is do/while looping.
        /// If until() comes before repeat() it is while/do looping
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Until(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));
            
            builder.AddArguments(traversal.GremlinArguments);
            return builder.Add($"until({traversal.Query})");
        }
    }
}