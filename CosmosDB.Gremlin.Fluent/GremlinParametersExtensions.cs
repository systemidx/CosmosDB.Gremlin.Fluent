using System.Text;

namespace CosmosDB.Gremlin.Fluent
{
    public static class GremlinParametersExtensions
    {
        public static string Expand(this IGremlinParameter[] parameters)
        {
            if (parameters == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parameters.Length; ++i)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(parameters[i].QueryStringValue);
            }

            return sb.ToString();
        }

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