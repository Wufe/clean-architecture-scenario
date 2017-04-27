using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Implementation
{
    public class DistributedCacheService : ICacheService
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IDistributedCache _cache;
        private readonly ISerializer _serializer;

        public DistributedCacheService(
            IDistributedCache cache,
            IConfigurationRoot configuration,
            ISerializer serializer
        )
        {
            _cache = cache;
            _configuration = configuration;
            _serializer = serializer;
        }

        public T Get<T>(string key)
        {
            byte[] entity = _cache.Get(key);
            if(entity != null)
                return
                    _serializer
                        .Deserialize<T>(
                            Encoding.UTF8.GetString(entity)
                        );
            return default(T);
        }

        public void Set(string key, object entity, string slidingExpirationTimespanConfig)
        {
            var timespanConfig = $"Cache:Lifetime:{slidingExpirationTimespanConfig}";

            var seconds = 0;
            var minutes = 0;
            var hours = 0;

            var secondsTimespan = int.TryParse(_configuration.GetSection($"{timespanConfig}:seconds").Value, out seconds);
            var minutesTimespan = int.TryParse(_configuration.GetSection($"{timespanConfig}:minutes").Value, out minutes);
            var hoursTimespan = int.TryParse(_configuration.GetSection($"{timespanConfig}:hours").Value, out hours);

            var totalTimespan =
                TimeSpan
                    .FromSeconds(0)
                    .Add(TimeSpan.FromSeconds(seconds))
                    .Add(TimeSpan.FromMinutes(minutes))
                    .Add(TimeSpan.FromHours(hours));

            Set(key, entity, totalTimespan);
        }

        public void Set(string key, object entity, TimeSpan slidingExpirationTimespan)
        {
            string serializedEntity = _serializer.Serialize(entity);
            _cache
                .Set(
                    key,
                    Encoding.UTF8.GetBytes(serializedEntity),
                    new DistributedCacheEntryOptions()
                    {
                        SlidingExpiration = slidingExpirationTimespan
                    }
                );
        }

        public void Refresh(string key)
        {
            _cache.Refresh(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
