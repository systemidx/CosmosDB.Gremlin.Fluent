using System.Text;

namespace CosmosDB.Gremlin.Fluent
{
    public static class GremlinParametersExtensions
    {
        public static string Expand(this GremlinParameter[] parameters)
        {
            if (parameters == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parameters.Length; ++i)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(parameters[i].Value);
            }

            return sb.ToString();
        }
    }
}