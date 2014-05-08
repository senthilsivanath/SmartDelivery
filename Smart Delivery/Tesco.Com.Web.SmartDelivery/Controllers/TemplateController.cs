using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using Jurassic;
using System.IO;

namespace Tesco.Com.Web.SmartDelivery.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Template/

        public MvcHtmlString Index()
        {
            return RenderRazorViewToString("Index", null);
        }

        public MvcHtmlString Vantrip()
        {
            return RenderRazorViewToString("Vantrip", null);
        }
        public MvcHtmlString Admin()
        {
            return RenderRazorViewToString("Admin", null);
        }
        public MvcHtmlString Training()
        {
            return RenderRazorViewToString("Training", null);
        }
        public MvcHtmlString Signout()
        {
            return RenderRazorViewToString("Signout", null);
        }
        public MvcHtmlString OrderGrid()
        {
            return RenderRazorViewToString("OrderGrid", null);
        }
        public MvcHtmlString Navigation()
        {
            return RenderRazorViewToString("Navigation", null);
        }
        public MvcHtmlString OrderDetail()
        {
            return RenderRazorViewToString("OrderDetail", null);
        }
        public MvcHtmlString AccidentSupport()
        {
            return RenderRazorViewToString("AccidentSupport", null);
        }
        public MvcHtmlString Substitutes()
        {
            return RenderRazorViewToString("Substitutes", null);
        }
        public MvcHtmlString RenderRazorViewToString(string viewName, object model)
        {
            Response.ContentType = "application/javascript";
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return new MvcHtmlString(PrecompileHandlebarsTemplate("template", sw.GetStringBuilder().ToString()));
            }
        }
        public string PrecompileHandlebarsTemplate(string name, string template)
        {
            try
            {
                var engine = new ScriptEngine();
                engine.ExecuteFile(Server.MapPath("/") + @"/js/handlebars.js");
                engine.Execute(@"var precompile = Handlebars.precompile;");
                return string.Format("var {0} = Handlebars.template({1});",
                    name, engine.CallGlobalFunction("precompile", template).ToString());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
