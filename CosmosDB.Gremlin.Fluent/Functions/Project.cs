using System.Linq;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class ProjectFunction
    {
        /// <summary>
        /// The project()-step (map) projects the current object into a Map&lt;String,Object&gt; keyed by provided labels.
        /// It is similar to <seealso cref="SelectFunction.Select"/>, save that instead of retrieving and modulating historic traverser state,
        /// it modulates the current state of the traverser
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Project(this GremlinQueryBuilder builder, params IGremlinParameter[] labels)
        {
            if (labels == null || !labels.Any())
                return builder.Add($"project()");
            if (!labels.All(l => l.TrueValue is string))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Project)} only accepts {nameof(labels)} that resolve to strings");
            
            builder.AddArguments(labels.OfType<GremlinArgument>().ToArray());
            return builder.Add($"project({labels.Expand()})");
        }
        
        /// <summary>
        /// The project()-step (map) projects the current object into a Map&lt;String,Object&gt; keyed by provided labels.
        /// It is similar to <seealso cref="SelectFunction.Select"/>, save that instead of retrieving and modulating historic traverser state,
        /// it modulates the current state of the traverser
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Project(this GremlinQueryBuilder builder, params string[] labels)
        {
            if (labels == null || !labels.Any())
                return builder.Add($"project()");

            return builder.Add(
                $"project({labels.Select(p => (IGremlinParameter) new GremlinParameter(p)).ToArray().Expand()})");
        }
    }
}