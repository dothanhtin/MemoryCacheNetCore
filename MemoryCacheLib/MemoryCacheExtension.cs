//using Microsoft.Extensions.Caching.Memory;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace MemoryCacheLib
{
    public class MemoryCacheExtension
    {
        private static readonly ObjectCache _cache = MemoryCache.Default;
        private static readonly long defaultExpiredTime = 60;
        public static void AddValue<T>(string key, T value)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(defaultExpiredTime)
            };
            _cache.Add(key, value, cacheItemPolicy);
        }

        public static void AddValue<T>(string key, T value,long timeOut)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(timeOut)
            };
            _cache.Add(key, value, cacheItemPolicy);
        }
        public static object GetValue(string key)
        {
            var result = _cache.Get(key);
            return result;
        }
        public static bool RemoveKey(string key)
        {
            try
            {
                while (_cache.Get(key) != null)
                    _cache.Remove(key);
                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool checkExistKey(string key)
        {
            var result = _cache.Get(key);
            if (result != null) return true;
            return false;
        }
    }
}
