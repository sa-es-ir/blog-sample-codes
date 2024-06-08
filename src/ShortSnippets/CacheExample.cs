using Microsoft.Extensions.Caching.Memory;

namespace ShortSnippets;

public class CacheExample
{
    private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions
    {
        SizeLimit = 1024 // Size limit of the cache
    });

    public T? GetDataFromCacheOrSource<T>(string cacheKey) where T : class, new()
    {
        // Try to get data from the cache
        if (_memoryCache.TryGetValue(cacheKey, out T? cachedData))
        {
            // Data found in cache, return it
            return cachedData;
        }

        // Data not found in cache, fetch it from the source
        var dataFromSource = GetExpensiveDataFromSource<T>();

        // Store the fetched data in the cache
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            // Cache data for 30 minutes
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            Size = 1 // Size of the cache entry
        };

        _memoryCache.Set(cacheKey, dataFromSource, cacheEntryOptions);

        return dataFromSource;
    }

    private T? GetExpensiveDataFromSource<T>() where T : class, new()
    {
        return new T();
    }
}
