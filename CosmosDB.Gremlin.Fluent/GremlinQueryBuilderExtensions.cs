﻿using System.Text;

namespace CosmosDB.Gremlin.Fluent
{
    public static class GremlinQueryBuilderExtensions
    {
        public static string Expand(this GremlinQueryBuilder[] innerBuilders)
        {
            if (innerBuilders == null)
                throw new GremlinQueryBuilderException();

            if (innerBuilders.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < innerBuilders.Length; ++i)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(innerBuilders[i].Query);
            }

            return sb.ToString();
        }
    }
}