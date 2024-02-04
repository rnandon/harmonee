var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var dbService = builder.AddSqlServerContainer("dbService").AddDatabase("group");

var apiservice = builder.AddProject<Projects.harmonee_ApiService>("apiservice")
	.WithReference(dbService);

builder.AddProject<Projects.harmonee_Web>("webfrontend")
	.WithReference(cache)
	.WithReference(apiservice);

builder.Build().Run();
