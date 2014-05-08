using System.Web;
using System.Web.Optimization;

namespace Tesco.Com.Web.SmartDelivery
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/Content/css").Include().Include("~/css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/yui").Include(
                           "~/js/yui_3.12.0/yui/build/yui/yui-min.js").Include(
                           "~/js/app.js"));

        }
    }
}