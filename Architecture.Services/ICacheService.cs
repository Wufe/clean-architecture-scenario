using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Set(string key, object entity, string slidingExpirationTimespanConfig);
        void Set(string key, object entity, TimeSpan slidingExpirationTimespan);
        void Refresh(string key);
        void Remove(string key);
    }
}
