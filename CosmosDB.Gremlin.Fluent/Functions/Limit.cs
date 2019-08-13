using System;
   
   namespace CosmosDB.Gremlin.Fluent.Functions
   {
       public static class LimitFunction
       {
           /// <summary>
           /// The limit()-step is analogous to <seealso cref="RangeFunction.Range(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/> save that the lower end range is set to 0.
           /// It can also be applied with local scope, in which case it operates on the incoming collection
           /// </summary>
           /// <param name="builder"></param>
           /// <param name="parameter"></param>
           /// <returns></returns>
           /// <exception cref="ArgumentNullException"></exception>
           /// <exception cref="GremlinQueryBuilderException"></exception>
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, IGremlinParameter parameter)
           {
               if (parameter == null)
                   throw new ArgumentNullException(nameof(parameter));
               if (!parameter.IsNumber(true))
                   throw new GremlinQueryBuilderException(
                       $"{nameof(Limit)} only supports numeric parameters and scope and " +
                       $"'{parameter.TrueValue}' does not appear to conform to this");
               
               builder.AddArgument(parameter as GremlinArgument);
               return builder.Add($"limit({parameter.QueryStringValue})");
           }
           
           /// <summary>
           /// The limit()-step is analogous to <seealso cref="RangeFunction.Range(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/> save that the lower end range is set to 0.
           /// It can also be applied with local scope, in which case it operates on the incoming collection
           /// </summary>
           /// <param name="builder"></param>
           /// <param name="parameter"></param>
           /// <returns></returns>
           /// <exception cref="ArgumentNullException"></exception>
           /// <exception cref="GremlinQueryBuilderException"></exception>
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, GremlinScope scope, IGremlinParameter parameter)
           {
               if (parameter == null)
                   throw new ArgumentNullException(nameof(parameter));
               if (!parameter.IsNumber(true))
                   throw new GremlinQueryBuilderException(
                       $"{nameof(Limit)} only supports numeric parameters and scope and " +
                       $"'{parameter.TrueValue}' does not appear to conform to this");
   
               builder.AddArgument(parameter as GremlinArgument);
               return builder.Add($"limit({scope.QueryStringValue},{parameter.QueryStringValue})");
           }

           /// <summary>
           /// The limit()-step is analogous to <seealso cref="RangeFunction.Range(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/> save that the lower end range is set to 0.
           /// It can also be applied with local scope, in which case it operates on the incoming collection
           /// </summary>
           /// <param name="builder"></param>
           /// <param name="parameter"></param>
           /// <returns></returns>
           /// <exception cref="ArgumentNullException"></exception>
           /// <exception cref="GremlinQueryBuilderException"></exception>
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, GremlinScope scope,
               long parameter)
           {
               // For implicit operators
               return builder.Limit(scope, (GremlinParameter) parameter);
           }
           
           /// <summary>
           /// The limit()-step is analogous to <seealso cref="RangeFunction.Range(CosmosDB.Gremlin.Fluent.GremlinQueryBuilder,CosmosDB.Gremlin.Fluent.IGremlinParameter,CosmosDB.Gremlin.Fluent.IGremlinParameter)"/> save that the lower end range is set to 0.
           /// It can also be applied with local scope, in which case it operates on the incoming collection
           /// </summary>
           /// <param name="builder"></param>
           /// <param name="parameter"></param>
           /// <returns></returns>
           /// <exception cref="ArgumentNullException"></exception>
           /// <exception cref="GremlinQueryBuilderException"></exception>
           public static GremlinQueryBuilder Limit(this GremlinQueryBuilder builder, long parameter)
           {
               // For implicit operators
               return builder.Limit((GremlinParameter) parameter);
           }

       }
   }