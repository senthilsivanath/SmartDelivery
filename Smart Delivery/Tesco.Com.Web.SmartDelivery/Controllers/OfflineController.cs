using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.Com.Web.Core.UIAssets;
using System.Web.Optimization;
using System.IO;
using System.Configuration;

namespace Tesco.Com.Web.SmartDelivery.Controllers
{
    public class OfflineController : Controller
    {
        public ActionResult Index(string language)
        {
            if (ConfigurationManager.AppSettings["enableAppCache"].ToUpper().Equals("TRUE"))
            {
                string templatePath = "/" + language + "/Template/Index";

                var files = GetFiles("/images");
                files.AddRange(GetFiles("/css"));
                files.AddRange(GetFiles("/js", new string[] { "yui_3.12.0", "Web.config" }));
                files.Add(Url.Content("~/js/yui_3.12.0/yui/build/yui/yui-min.js"));
                files.AddRange(GetFiles("/Views/Template", language: language));

                return getAppCacheResult(files);
            }
            else
                return View();
        }

        private AppCacheResult getAppCacheResult(List<string> files)
        {
            AppCacheResult result = new AppCacheResult(files, fingerprint: DateTime.Now.ToShortDateString());
            return result;
        }

        private List<string> GetFiles(string rootdirectory, string[] excludedirectory = null, string language = "")
        {
            List<string> cacheAssests = new List<string>();
            string Path = Server.MapPath(rootdirectory);
            if (excludedirectory == null)
            {
                excludedirectory = new string[] { "" };
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            cacheAssests.AddRange(directoryInfo.GetFiles().Where(x => !excludedirectory.Contains(x.Name)).Select(x => new
            {
                file = System.IO.Path.GetExtension(x.FullName) == ".cshtml" ? "/" + language + "/" + Url.Content(getVirtualPath(x.FullName)).Replace(".cshtml", "").Replace("/Views/", "")
                : Url.Content(getVirtualPath(x.FullName)).Replace(".cshtml", "").Replace("/Views/", "")
            }.file

            ).ToList());

            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            foreach (var directory in directories)
            {
                if (IsExist(excludedirectory, directory.FullName))
                {
                    cacheAssests.AddRange(directory.GetFiles("*", SearchOption.AllDirectories).Where(x => !excludedirectory.Contains(x.Name)).Select(x => new { file = Url.Content(getVirtualPath(x.FullName)) }.file).ToList());
                }
            }

            return cacheAssests;
        }

        private bool IsExist(string[] excludedirectory, string directoryName)
        {
            if (excludedirectory == null)
                return true;

            foreach (var file in excludedirectory)
            {
                if (directoryName.IndexOf(file) > 0)
                {
                    return false;
                }
            }

            return true;

        }

        private string getVirtualPath(string physicalPath)
        {
            string path = string.Empty;

            if (physicalPath.StartsWith(Request.PhysicalApplicationPath))
            {
                path = "~/" + physicalPath.Substring(Request.PhysicalApplicationPath.Length)
                 .Replace("\\", "/");
            }

            return path;
        }


    }
}
