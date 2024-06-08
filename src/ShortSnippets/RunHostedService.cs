using Microsoft.Extensions.Hosting;

namespace ShortSnippets;

internal class RunHostedService : IHostedService
{
    private readonly CacheExample _cacheExample;

    public RunHostedService(CacheExample cacheExample)
    {
        _cacheExample = cacheExample;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var cacheKey = "TestCacheKey";

        var data = _cacheExample.GetDataFromCacheOrSource<TestCacheModel>(cacheKey)!;

        Console.WriteLine($"Data from cache: {data.Name} - {data.Age}");

        return Task.CompletedTask;

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

public class TestCacheModel
{
    public string Name { get; set; } = Guid.NewGuid().ToString();

    public int Age { get; set; } = Random.Shared.Next(1, 100);
}

