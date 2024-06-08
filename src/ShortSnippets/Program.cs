using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShortSnippets;

Console.WriteLine("Hello, World!");

var builder = Host.CreateApplicationBuilder();

var configuration = builder.Configuration;

builder.Services.AddMemoryCache();

builder.Services.Configure<SampleOptions>(configuration.GetSection("Config"));

builder.Services.AddSingleton<SampleService>();
builder.Services.AddSingleton<CacheExample>();

builder.Services.AddHostedService<RunHostedService>();

var app = builder.Build();

app.Run();