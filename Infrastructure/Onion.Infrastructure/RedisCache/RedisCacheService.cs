using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Onion.Application.Interfaces.RedisCache;
using StackExchange.Redis;

namespace Onion.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer redisConnection;
        private readonly IDatabase database;
        private readonly RedisCacheSettings _settings;

        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            _settings = options.Value;
            var opt = ConfigurationOptions.Parse(_settings.ConnectionString);
            redisConnection= ConnectionMultiplexer.Connect(opt);
            if (!redisConnection.IsConnected)
            {
                throw new Exception("Redis bağlantısı kurulamadı.");
            }
            database = redisConnection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
          TimeSpan time = expirationTime.Value - DateTime.Now;
          await database.StringSetAsync(key, JsonConvert.SerializeObject(value),time);

         
        }
    }
}
