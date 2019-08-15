namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class BarrierFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The barrier()-step (barrier) turns the lazy traversal pipeline into a bulk-synchronous pipeline. This step is useful in the following situations:
        /// When everything prior to barrier() needs to be executed before moving onto the steps after the barrier() (i.e. ordering).
        /// When "stalling" the traversal may lead to a "bulking optimization" in traversals that repeatedly touch many of the same elements (i.e. optimizing).
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter">If barrier() is provided an integer argument, then the barrier will only hold n-number
        /// of unique traversers in its barrier before draining the aggregated traversers to the next step</param>
        /// <returns></returns>
        public static GremlinQueryBuilder Barrier(this GremlinQueryBuilder builder, IGremlinParameter parameter = null)
        {
            if (parameter == null)
            {
                return builder.Add("barrier()");
            }
            else
            {
                if (!(parameter.TrueValue is int))
                    throw new GremlinQueryBuilderException(
                        $"{nameof(Barrier)} only accepts integer parameters and {parameter.TrueValue} does not appear to be");

                builder.AddArgument(parameter as GremlinArgument);
                return builder.Add($"barrier({parameter.QueryStringValue})");
            }
        }
    }
}
