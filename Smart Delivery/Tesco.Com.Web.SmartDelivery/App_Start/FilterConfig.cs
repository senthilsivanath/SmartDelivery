using System.Web;
using System.Web.Mvc;

namespace Tesco.Com.Web.SmartDelivery
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}