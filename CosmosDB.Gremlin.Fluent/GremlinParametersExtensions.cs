using System.Linq;
using System.Text;

namespace CosmosDB.Gremlin.Fluent
{
    /// <summary>
    /// Extension class for Gremlin parameters
    /// </summary>
    public static class GremlinParametersExtensions
    {
        /// <summary>
        /// Combine multiple parameters into a single query string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Expand(this IGremlinParameter[] parameters)
        {
            return parameters == null ? string.Empty : string.Join(",", parameters.Select(p => p.QueryStringValue));
        }

        /// <summary>
        /// Check is supplied parameter holds a numeric value
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="wholeNumberOnly">If true, reject floating point-capable types</param>
        /// <returns></returns>
        public static bool IsNumber(this IGremlinParameter parameter, bool wholeNumberOnly = false)
        {
            return parameter.TrueValue is sbyte
                   || parameter.TrueValue is byte
                   || parameter.TrueValue is short
                   || parameter.TrueValue is ushort
                   || parameter.TrueValue is int
                   || parameter.TrueValue is uint
                   || parameter.TrueValue is long
                   || parameter.TrueValue is ulong
                   || (parameter.TrueValue is float && !wholeNumberOnly)
                   || (parameter.TrueValue is double && !wholeNumberOnly)
                   || (parameter.TrueValue is decimal && !wholeNumberOnly);
        }
    }
}