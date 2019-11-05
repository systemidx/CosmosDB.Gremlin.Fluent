using CosmosDB.Gremlin.Fluent;

namespace CosmosDB.Gremlin.Fluent.Functions
{
#pragma warning disable 1591
    public static class GroupFunction
#pragma warning restore 1591
    { 
        /// <summary>
        /// As traversers propagate across a graph as defined by a traversal, sideEffect computations are sometimes required.
        /// That is, the actual path taken or the current location of a traverser is not the ultimate output of the
        /// computation, but some other representation of the traversal.
        /// The group()-step (map/sideEffect) is one such sideEffect that organizes the objects according to
        /// some function of the object. Then, if required, that organization (a list) is reduced
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Group(this GremlinQueryBuilder builder, IGremlinParameter value = null)
        {
            if (value == null)
            {
                return builder.Add($"group()");
            }
            else
            {
                if (!(value.TrueValue is string))
                    throw new GremlinQueryBuilderException($"{nameof(Group)} requires supplied parameter to " +
                                                           $"resolve to a string and {value.TrueValue} does not appear to");
                
                builder.AddArgument(value as GremlinArgument);
                return builder.Add($"group({value.QueryStringValue})");
            }
        }
        
        /// <summary>
        /// As traversers propagate across a graph as defined by a traversal, sideEffect computations are sometimes required.
        /// That is, the actual path taken or the current location of a traverser is not the ultimate output of the
        /// computation, but some other representation of the traversal.
        /// The group()-step (map/sideEffect) is one such sideEffect that organizes the objects according to
        /// some function of the object. Then, if required, that organization (a list) is reduced
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder Group(this GremlinQueryBuilder builder, string parameter)
        {
            // for implicit conversion operators
            return builder.Group((GremlinParameter)parameter);
        }
    }
}