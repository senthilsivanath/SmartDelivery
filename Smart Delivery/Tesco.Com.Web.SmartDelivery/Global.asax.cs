﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Tesco.Com.Web.SmartDelivery
{

    public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas(); 
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
		}
	}
}