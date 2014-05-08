using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Tesco.Com.Web.Core.UIAssets
{
	public class CacheHelper
	{

		public void SetConditionalCacheHeaders(HttpContext context, string hash)
		{
			context.Response.ClearHeaders();
			context.Response.AppendHeader("Etag", hash);

			////	last modified time based on last application build
			//SetLastModified(context);

			//	allow aggressive caching 
			context.Response.Cache.SetCacheability(HttpCacheability.Public);
		}

		public void SetCacheHeaders(HttpContext context, string hash)
		{
			context.Response.ClearHeaders();
			context.Response.AppendHeader("Etag", hash);

			//	allow aggressive caching 
			context.Response.Cache.SetCacheability(HttpCacheability.Public);

			//  expiry headers, load from web.config
			int maxAge = Convert.ToInt32(new UIAssetsHelper().GetSetting("max-age"));

		//	TimeSpan expiryTime = new TimeSpan(maxAge, 0, 0, 0);
		// use expires as max-age is measured against
	//		context.Response.Cache.SetMaxAge(expiryTime);
			context.Response.Cache.SetExpires(DateTime.Now.AddDays(maxAge));
		}

		//public void SetLastModified(HttpContext context)
		//{
		//	//	todo: profile this
		//	//	todo: this will need to change as templates etc. may change outside of software release, eg MVT.
		//	string folder = Path.Combine(context.Server.MapPath("~/"), "bin");
		//	context.Response.AddFileDependencies(Directory.GetFiles(folder, "*.dll"));
		//	context.Response.Cache.SetLastModifiedFromFileDependencies();
		//}

		public bool IsEtagCurrent(HttpContext context, string hash)
		{
			// request has etag?
			return !string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_IF_NONE_MATCH"]) &&
				context.Request.ServerVariables["HTTP_IF_NONE_MATCH"].Equals(hash);
		}

		//public bool IsModifiedDateStale(HttpContext context)
		//{
		//	//	out going date
		//	string requestModified = context.Response.Headers["Last-Modified"];

		//	//
		//	DateTime lastModified;
		//	DateTime.TryParse(context.Response.Headers["Last-Modified"], out lastModified);

		//	//	date of requested item
		//	DateTime ifModifiedSince;
		//	DateTime.TryParse(context.Request.Headers["If-Modified-Since"], out ifModifiedSince);

		//	//	might be in the browser cache
		//	return (lastModified != null && ifModifiedSince != null && lastModified > ifModifiedSince);
		//}

		public string GetMd5Sum(string str)
		{
			//  convert the string into bytes
			Encoder enc = Encoding.Unicode.GetEncoder();

			//  Create a buffer 
			byte[] unicodeText = new byte[str.Length * 2];
			enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

			//  hash byte array
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] result = md5.ComputeHash(unicodeText);

			// Build the final string by converting each byte
			// into hex and appending it to a StringBuilder
			StringBuilder sb = new StringBuilder();
			sb.Append("\"");
			for (int i = 0; i < result.Length; i++)
			{
				sb.Append(result[i].ToString("X2"));
			}
			sb.Append("\"");
			return sb.ToString();
		}
	}
}
