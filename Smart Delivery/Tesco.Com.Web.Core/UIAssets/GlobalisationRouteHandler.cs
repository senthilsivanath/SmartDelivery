using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;

namespace Tesco.Com.Web.Core.UIAssets
{
    public class GlobalisationRouteHandler : MvcRouteHandler
    {
        RouteValueDictionary RouteDataValues { get; set; }

        string CultureValue
        {
            get
            {
                return (string)RouteDataValues[GlobalisedRoute.CultureKey];
            }
        }

        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            RouteDataValues = requestContext.RouteData.Values;
            CultureManager.SetCulture(CultureValue);
            return base.GetHttpHandler(requestContext);
        }
    }
}
