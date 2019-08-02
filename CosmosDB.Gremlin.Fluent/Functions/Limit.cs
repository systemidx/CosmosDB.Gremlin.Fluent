using System;
   
   namespace CosmosDB.Gremlin.Fluent.Functions
   {
       public static class LimitFunction
       {
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, IGremlinParameter parameter)
           {
               if (parameter == null)
                   throw new ArgumentNullException(nameof(parameter));
               if (!long.TryParse(parameter.Value, out _))
                   throw new GremlinQueryBuilderException(
                       $"{nameof(Limit)} only supports numeric parameters and scope and '{parameter.Value}' does not appear to conform to this");
               
               return builder.Add($"limit({parameter.Value})");
           }
           
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
           {
               if (parameter == null)
                   throw new ArgumentNullException(nameof(parameter));
               if (!long.TryParse(parameter.Value, out _))
                   throw new GremlinQueryBuilderException(
                       $"{nameof(Limit)} only supports numeric parameters and scope and '{parameter.Value}' does not appear to conform to this");
   
               return builder.Add($"limit({scope.Value},{parameter.Value})");
           }

           // For implicit operators
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, GremlinScope scope,
               GremlinParameter parameter)
           {
               return builder.Limit(scope, (IGremlinParameter) parameter);
           }
           
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, GremlinParameter parameter)
           {
               return builder.Limit((IGremlinParameter) parameter);
           }

       }
   }