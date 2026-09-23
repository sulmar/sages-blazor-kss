using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Training.Blazor.Services;

public static class DistributedCacheRedisExtensions
{
    public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordKey,
            T data,
            TimeSpan? absolutetime = null)
    {
        if (recordKey == null)
        {
            throw new ArgumentNullException(nameof(recordKey));
        }

        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = absolutetime ?? TimeSpan.FromMinutes(2),
        };

        var recordJson = JsonSerializer.Serialize(data);
        await cache.SetStringAsync(recordKey, recordJson, options);
    }

    public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordKey)
    {
        if (recordKey == null)
        {
            throw new ArgumentNullException(nameof(recordKey));
        }

        var recordJson = await cache.GetStringAsync(recordKey);

        return recordJson is null
            ? default(T)
            : JsonSerializer.Deserialize<T>(recordJson);
    }
}
