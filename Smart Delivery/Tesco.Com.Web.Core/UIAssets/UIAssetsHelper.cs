
using System.Configuration;
using System.Reflection;
using System.Web;

namespace Tesco.Com.Web.Core.UIAssets
{
	public class UIAssetsHelper
	{
		public string GetVersion()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			AssemblyName assemblyName = assembly.GetName();

			return assemblyName.Version.ToString();
		}

		public string GetSetting(string name)
		{
			string result = "";
			UIAssetsSection uiassetsSection = (UIAssetsSection)ConfigurationManager.GetSection("uiassets");
			if (uiassetsSection.Settings.Count > 0)
			{
				foreach (SettingConfigurationElement setting in uiassetsSection.Settings)
				{
					if (name == setting.Name) 
					{
						result = setting.Value;
						break;
					}
				}
			}
			return result;
		}

		public bool GetCompressionSetting()
		{
			bool setting = GetSetting("compress") == "true";
			bool userOverride = HttpContext.Current.Request.QueryString["compress"] == "false";
			return !userOverride && setting;
		}
	}
}
