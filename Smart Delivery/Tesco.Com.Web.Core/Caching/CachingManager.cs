using System;
using System.Runtime.Caching;

namespace Tesco.Com.Web.Core.Caching
{
	/// <summary>
	/// Static instance of mem cache
	/// </summary>
	public sealed class CachingManager
	{
		private static CachingManager cacheManagerObject = null;
		private static readonly ObjectCache cache = MemoryCache.Default;
		private static object contentObjSync = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="CachingManager"/> class.
		/// </summary>
		private CachingManager()
		{
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static CachingManager Instance
		{
			get
			{
				if (cacheManagerObject == null)
				{
					lock (contentObjSync)
					{
						if (cacheManagerObject == null)
						{
							cacheManagerObject = new CachingManager();
						}
					}
				}
				return cacheManagerObject;
			}
		}

		/// <summary>
		/// Adds the item.
		/// </summary>
		/// <param name="objectToCache">The object to cache.</param>
		/// <param name="key">The key.</param>
		public void AddItem(object objectToCache, string key)
		{
			cache.Add(key, objectToCache, DateTime.UtcNow.AddDays(1));
		}

		/// <summary>
		/// Adds the item to cache and invalidate after 24 hours.
		/// </summary>
		/// <param name="objectToCache">The object to cache.</param>
		/// <param name="key">The key.</param>
		public void AddItem(object objectToCache, string key, DateTime expiryTime)
		{
			cache.Add(key, objectToCache, expiryTime);
		}

		/// <summary>
		/// Adds the item to cache and invalidates based on the policy.
		/// </summary>
		/// <param name="objectToCache">The object to cache.</param>
		/// <param name="key">The key.</param>
		/// <param name="policy">The policy.</param>
		public void AddItem(object objectToCache, string key, CacheItemPolicy policy)
		{
			cache.Add(key, objectToCache, policy);
		}

		/// <summary>
		/// Adds the cache if not present or get the existing cache by key.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objectToCache">The object to cache.</param>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public T AddOrGet<T>(object objectToCache, string key) where T : class
		{
			return (T)cache.AddOrGetExisting(key, objectToCache, DateTime.UtcNow.AddDays(1));
		}

		/// <summary>
		/// Determines whether cache [contains] [the specified key].
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// 	<c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains(string key)
		{
			return cache.Contains(key);
		}

		/// <summary>
		/// Gets the specified cache.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public T Get<T>(string key) where T : class
		{
			try
			{
				return (T)cache[key];
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Removes the specified key from cache.
		/// </summary>
		/// <param name="key">The key.</param>
		public void Remove(string key)
		{
			cache.Remove(key);
		}
	}
}