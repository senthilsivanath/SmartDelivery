using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Tesco.Com.Web.Core.UIAssets
{
    public class GlobalisedRoute : Route
    {
        public const string CultureKey = "culture";

        static string CreateCultureRoute(string unGlobalisedUrl)
        {
            return string.Format("{{" + CultureKey + "}}/{0}", unGlobalisedUrl);
        }

        public GlobalisedRoute(string unGlobalisedUrl, RouteValueDictionary defaults) :
            base(CreateCultureRoute(unGlobalisedUrl),
               defaults, new RouteValueDictionary(new { culture = new CultureRouteConstraint() }), new GlobalisationRouteHandler())
        {

        }

    }
}
