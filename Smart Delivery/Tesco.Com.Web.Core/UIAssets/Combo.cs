using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Runtime.Caching;
using System.Net;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Tesco.Com.Web.Core.UIAssets
{
	using Yahoo.Yui.Compressor;
	using Tesco.Com.Web.Core.Caching;
	//using Tesco.Com.Web.Core.Routes;

	public class Combo : IHttpHandler
	{
		#region private variables
		private string hash;
		private HttpContext context;
		private List<string> filePaths;
		private CssCompressor _cssCompressor = null;
		private JavaScriptCompressor _javascriptCompressor = null;
		private int lineBreakPosition = -1;

		private const string JAVASCRIPT_CONTENT_TYPE = "application/javascript";
		private const string CSS_CONTENT_TYPE = "text/css";
		#endregion

		#region getters
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		private CssCompressor cssCompressor
		{
			get
			{
				if (_cssCompressor == null)
				{
					_cssCompressor = new CssCompressor();
					_cssCompressor.CompressionType = Yahoo.Yui.Compressor.CompressionType.Standard;
					_cssCompressor.LineBreakPosition = lineBreakPosition;
				}
				return _cssCompressor;
			}
		}

		private JavaScriptCompressor javascriptCompressor
		{
			get
			{
				if (_javascriptCompressor == null)
				{
					_javascriptCompressor = new JavaScriptCompressor();
					_javascriptCompressor.CompressionType = Yahoo.Yui.Compressor.CompressionType.Standard;
					_javascriptCompressor.LineBreakPosition = lineBreakPosition;
				}
				return _javascriptCompressor;
			}
		}
		#endregion

		//  combine, compress and cache requested js or css files
		public void ProcessRequest(HttpContext httpContext) 
        {
			//	
			CacheHelper cacheHelper = new CacheHelper();
			
			//
			filePaths = new List<string>();
            context = httpContext;

			string contentType;

            // create a string for the cache
            string key = context.Request.Url.AbsoluteUri.ToLower();
            StringBuilder sb = new StringBuilder();

			// get the names of the requested files
			string[] files = GetFiles();

			// check what type of file it is (js or css)
			string extension = Path.GetExtension(files[0]);

			//	compress it?
			bool compress = new UIAssetsHelper().GetCompressionSetting();	
				
			// set the content type
			contentType = (extension == ".js") ? JAVASCRIPT_CONTENT_TYPE : (extension == ".css" ? CSS_CONTENT_TYPE : "");

            //  create hashed etag
            hash = cacheHelper.GetMd5Sum(key);

            Uri baseUri = new Uri(context.Request.Url.AbsoluteUri);

            // check if file is in server cache
            if (CachingManager.Instance.Get<string>(key) == null)
            {
                foreach (string file in files)
                {
					string content = GetFile(baseUri, file);

					if (compress) 
					{
						switch (contentType)
						{
							case JAVASCRIPT_CONTENT_TYPE:
								sb.AppendLine(javascriptCompressor.Compress(content));
								break;
							case CSS_CONTENT_TYPE:
								sb.AppendLine(cssCompressor.Compress(content));
								break;
							default:
								sb.AppendLine(content);
								break;
						}
					}
					else
					{
						sb.AppendLine(content);
					}
                }

                //  cache, set dependency
				if (filePaths.Count > 0)
				{
					CacheItemPolicy policy = new CacheItemPolicy();
					
					policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

					CachingManager.Instance.AddItem(sb.ToString(), key, policy);
				}
				else
				{
					CachingManager.Instance.AddItem(sb.ToString(), key);
				}
            }
			else if (cacheHelper.IsEtagCurrent(context, hash))   //  in the server cache then it might be in the browser cache
			{
				cacheHelper.SetCacheHeaders(context, hash);

				//  send not modified header
				context.Response.Status = "304 Not Modified";
				context.Response.AppendHeader("Content-Length", "0");
                
				return;
			}
		
			//  set the headers
			cacheHelper.SetCacheHeaders(context, hash);

			//	todo: needs to set last-modified from original files
			//cacheHelper.SetLastModified(context);

			//	write out the response 
			context.Response.Write(CachingManager.Instance.Get<string>(key));

			//	add the mimetype 
			context.Response.ContentType = contentType;
			context.Response.Charset = "utf-8";
        }

		private string GetFile(Uri baseUri, string file)
		{
			Uri uri = new Uri(baseUri, HttpUtility.UrlDecode(file));
            UIAssetsHelper uiAssetsHelper = new UIAssetsHelper();
            string basePath =  uiAssetsHelper.GetSetting("js");
            string path = context.Server.MapPath(basePath + uri.AbsolutePath);
			string result = "";

			if (File.Exists(path))
			{
				result = File.ReadAllText(path);
				filePaths.Add(path);
			} 
			else 
			{
				string filename = Path.GetFileNameWithoutExtension(file);
                //RouteInfo routeInfo = new RouteInfo(uri, HttpContext.Current.Request.ApplicationPath);

				
                ////	routed URL?
                //if (uri.IsRouteMatch(routeInfo, "UIAssets", filename))
                //{
                //    result = GetUIAssetsAction(filename, routeInfo);
                //}
			}
			return result;
		}

        //private string GetUIAssetsAction(string filename, RouteInfo routeInfo)
        //{
        //    var controllerContext = new ControllerContext(
        //        new HttpContextWrapper(HttpContext.Current), 
        //        routeInfo.RouteData, 
        //        new TempController()
        //    );

        //    //	Use HtmlHelper to render partial view to fake context
        //    var html = new HtmlHelper(
        //        new ViewContext(
        //            controllerContext,
        //            new TempView(), 
        //            new ViewDataDictionary(), 
        //            new TempDataDictionary(),
        //            context.Response.Output
        //        ),
        //        new ViewPage()
        //    );
        //    return html.Action(filename, "UIAssets").ToString();
        //}

		private string[] GetFiles()
		{
			return context.Request.QueryString.GetValues(0);
		}

		private class TempController : Controller { }

		private class TempView : IView
		{
			public void Render(ViewContext viewContext, System.IO.TextWriter writer)
			{
				throw new NotImplementedException();
			}
		}
	}
}
