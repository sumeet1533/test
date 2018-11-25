using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Performance.Data.Service.Components
{
	/// <summary>An extensions.</summary>
	public static class Extensions
	{
		/// <summary>A HttpRequestBase extension method that gets request identifier.</summary>
		/// <param name="request">The request to act on.</param>
		/// <returns>The request identifier.</returns>
		public static string GetRequestId(this HttpRequestBase request)
		{
			Func<string> getRequestIdCache = () => request.Cookies["RequestId"]?.Value ??
													request.Headers[HttpHeaders.Custom.RequestIdHeader] ??
													Guid.NewGuid().ToString("N");

			return request.RequestContext.HttpContext.EnsureInRequestCache("RequestId", () => getRequestIdCache());
		}

		/// <summary>A HttpRequestMessage extension method that gets request identifier.</summary>
		/// <param name="request">The request to act on.</param>
		/// <returns>The request identifier.</returns>
		public static string GetRequestId(this HttpRequestMessage request)
		{
			IEnumerable<string> output;
			return request.Headers
				.TryGetValues(HttpHeaders.Custom.RequestIdHeader, out output)
				? output.SingleOrDefault()
				: null;
		}

		/// <summary>A HttpContext extension method that gets current context.</summary>
		/// <param name="context">The context.</param>
		/// <returns>The current context.</returns>
		public static HttpContextBase GetCurrentContext(this HttpContext context)
		{
			return context == null ? null : new HttpContextWrapper(context);
		}

		/// <summary>
		/// Ensures an item is in the request cache.
		/// </summary>
		/// <typeparam name="T">The type of item contained in the cache.</typeparam>
		/// <param name="context">The context.</param>
		/// <param name="key">The key used to identify the item in the cache.</param>
		/// <param name="factory">The factory to construct the item if it does not yet exist in the cache.</param>
		/// <returns>The item from the cache.</returns>
		public static T EnsureInRequestCache<T>(this HttpContextBase context, object key, Func<T> factory)
		{
			IDictionary requestCache = context.Items;

			if (!requestCache.Contains(key))
			{
				lock (requestCache)
				{
					if (!requestCache.Contains(key))
					{
						requestCache[key] = factory();
					}
				}
			}

			return (T)requestCache[key];
		}
	}
}