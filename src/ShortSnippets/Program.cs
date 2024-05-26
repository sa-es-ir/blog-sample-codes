// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShortSnippets;

Console.WriteLine("Hello, World!");

var builder = Host.CreateApplicationBuilder();

builder.Services.Configure<SampleOptions>(builder.Configuration.GetSection("Config"));
builder.Services.AddSingleton<SampleService>();