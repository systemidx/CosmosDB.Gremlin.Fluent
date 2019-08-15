namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class EmitFunction
#pragma warning restore 1591
    {
        /// <summary>
        /// The emit-step is not an actual step, but is instead a step modulator for repeat().
        /// With emit(), the traverser is split in two — the traverser exits the code block as well as
        /// continues back within the code block (assuming until() holds true).
        /// The predicate for an empty argument emit() is true (i.e. emit() == emit{true}).
        /// If emit() is placed after repeat(), it is evaluated on the traversers leaving the repeat-traversal.
        /// If emit() is placed before repeat(), it is evaluated on the traversers prior to entering the repeat-traversal
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="traversal"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Emit(this GremlinQueryBuilder builder, GremlinQueryBuilder traversal = null)
        {
            if (traversal == null)
            {
                return builder.Add("emit()");
            }
            else
            {
                builder.AddArguments(traversal.GremlinArguments);
                return builder.Add($"emit({traversal.Query})");
            }
        }
    }
}