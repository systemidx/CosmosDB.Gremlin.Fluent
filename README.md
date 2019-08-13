[![Build Status](https://dev.azure.com/aieat/CosmosDB.Gremlin.Fluent/_apis/build/status/AieatAssam.CosmosDB.Gremlin.Fluent?branchName=master)](https://dev.azure.com/aieat/CosmosDB.Gremlin.Fluent/_build/latest?definitionId=1&branchName=master)

![Azure DevOps builds](https://img.shields.io/azure-devops/build/aieat/CosmosDb.Gremlin.Fluent/1)

![Azure DevOps tests](https://img.shields.io/azure-devops/tests/aieat/CosmosDb.Gremlin.Fluent/1)
# CosmosDB.Gremlin.Fluent
### A fluent query builder for Gremlin queries.
Azure CosmosDB Gremlin API does not support Java bytecode as of August 2019. This makes writing queries in Gremlin require constructing them using regular strings. 
This process is prone to errors with lack of any completions of syntax check.

To solve this issue, this library allows constructing Gremlin API queries using fluent API designed to cover all Gremlin features supported by CosmosDB Gremlin implementation. To further assist with writing production ready queries, there is support for Gremlin arguments built in. Arguments are tracked, validated and maintained automatically, allowing the developer to focus on writing queries and not keeping track of all the arguments used.

To get started, create a new instance of *GremlinQueryBuilder*:

```C#
var builder = new GremlinQueryBuilder()
```
You can then start chaining Gremlin invocations on the builder:
```C#
builder.G().V().HasId(new GremlinProperty("some identifier")).ValueMap(true);
```
or
```C#
var identifier = "some identifier";
builder.G().V().HasId(new GremlinArgument(nameof(identifier),identifier)).ValueMap(true);
```
The query can then be executed by Gremlin.NET client:
```C#
gremlinDotNetClient.SubmitAsync<Dictionary<string,object>>(builder.Query, builder.Arguments);
```
For queries that utilise partition keys, these can be defined directly on graph traversal source invocation
```C#
builder.G("partitonKeyName", "KeyValue1", "KeyValue2").V("some identifier");
```
To simplify writing queries with simple parameters, implicit conversion operators have been defined for common types, allowing to write
```C#
builder.G().V("identifier");
```
instead of
```C#
builder.G().V(new GremlinParameter("identifier"));
```

The library has support for all functions listed at the [official CosmosDB Gremlin support page](https://docs.microsoft.com/en-us/azure/cosmos-db/gremlin-support) as well as a number of ones listed on various other Gremlin-related MSDN articles (such as support for partition key strategy definition, within and without). 

Because this library does not generate any Gremlin bytecode and is merely providing an abstraction to facilitate writing string-based Gremlin queries, it can be used with a number of Gremlin client implementations. However, syntax generated is CosmosDB specific, since there are a few disagreements between TinkerPop and CosmosDB syntax flavours (one example is defining partition key strategy).
