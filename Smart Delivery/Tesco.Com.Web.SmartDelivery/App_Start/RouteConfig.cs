using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tesco.Com.Web.Core.UIAssets;

namespace Tesco.Com.Web.SmartDelivery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.combo/{*pathInfo}");

            const string defautlRouteUrl = "{controller}/{action}/{id}";
            RouteValueDictionary defaultRouteValueDictionary = new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //RouteValueDictionary cacheRouteValueDictionary = new RouteValueDictionary(new { controller = "offline", action = "index", id = UrlParameter.Optional });
            routes.MapRoute("appcache", "offline.appcache", new { controller = "offline", action = "index" });

            //routes.Add("OfflineCache",new Route(defautlRouteUrl
            routes.Add("DefaultGlobalised", new GlobalisedRoute(defautlRouteUrl, defaultRouteValueDictionary));
            routes.Add("Default", new Route(defautlRouteUrl, defaultRouteValueDictionary, new MvcRouteHandler()));
        }
    }
}