using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class GFunction
    {
        public static GremlinQueryBuilder G(this GremlinQueryBuilder builder)
        {
            return builder.Add("g");
        }
    }
}
