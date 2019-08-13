using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class GFunction
    {
        /// <summary>
        /// Create a new graph traversal source
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static GremlinQueryBuilder G(this GremlinQueryBuilder builder)
        {
            return builder.Add("g");
        }
        
        /// <summary>
        /// Create a new graph traversal source with supplied read
        /// partition key and value as part of its partition strategy.
        /// CosmosDB does not support assigning write partition in the strategy,
        /// so these need to be set to vertices directly
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="partitionKey">Partition key property name</param>
        /// <param name="readPartitions">One or more partitions to read data from</param>
        /// <returns></returns>
        public static GremlinQueryBuilder G(this GremlinQueryBuilder builder, string partitionKey, params string[] readPartitions)
        {
            if (!(readPartitions?.Any() ?? false))
                throw new GremlinQueryBuilderException(
                    $"At least one partition value is required in {nameof(readPartitions)}");
            if (string.IsNullOrWhiteSpace(partitionKey))
                throw new GremlinQueryBuilderException($"{nameof(partitionKey)} cannot be blank");
            
            // CosmosDB as of August 2019 does not support setting write partition. When this changes, writePartition('')
            // as part of partition strategy definition will allow not having to manually assign partition to vertices created
            return builder.Add(
                $"g.withStrategies(PartitionStrategy.build().partitionKey('{partitionKey}')" +
                $".readPartitions({string.Join(",", readPartitions.Select(p => "'" + p + "'"))})" +
                $".create())");
        }
        
        /// <summary>
        /// Create a new graph traversal source with supplied read
        /// partition key and value as part of its partition strategy.
        /// CosmosDB does not support assigning write partition in the strategy,
        /// so these need to be set to vertices directly
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="partitionKey">Partition key property name</param>
        /// <param name="readPartitions">One or more partitions to read data from</param>
        /// <returns></returns>
        public static GremlinQueryBuilder G(this GremlinQueryBuilder builder, string partitionKey, params IGremlinParameter[] readPartitions)
        {
            if (!(readPartitions?.Any() ?? false))
                throw new GremlinQueryBuilderException(
                    $"At least one partition value is required in {nameof(readPartitions)}");
            if (string.IsNullOrWhiteSpace(partitionKey))
                throw new GremlinQueryBuilderException($"{nameof(partitionKey)} cannot be blank");
            
            builder.AddArguments(readPartitions.OfType<GremlinArgument>().ToArray());
            // CosmosDB as of August 2019 does not support setting write partition. When this changes, writePartition('')
            // as part of partition strategy definition will allow not having to manually assign partition to vertices created
            return builder.Add(
                $"g.withStrategies(PartitionStrategy.build().partitionKey('{partitionKey}')" +
                $".readPartitions({readPartitions.Expand()})" +
                $".create())");
        }
    }
}
