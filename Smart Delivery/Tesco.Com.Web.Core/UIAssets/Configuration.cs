
using System.Configuration;
using System.Collections.Generic;
using System;

namespace Tesco.Com.Web.Core.UIAssets
{
	#region Custom Configuration Elements

	/// <summary>
	/// Custom content security configuration section
	/// </summary>
	public class UIAssetsSection : ConfigurationSection
	{
		/// <summary>
		/// policies collection
		/// </summary>
		[ConfigurationProperty("settings")]
		[ConfigurationCollection(typeof(ConfigurationCollection<SettingConfigurationElement>), AddItemName = "setting")]
		public ConfigurationCollection<SettingConfigurationElement> Settings
		{
			get { return (ConfigurationCollection<SettingConfigurationElement>)base["settings"]; }
		}
	}

	/// <summary>
	/// policy configuration element (child of policies collection)
	/// 
	/// </summary>
	public class SettingConfigurationElement : ConfigurationElement, IKey
	{
		/// <summary>
		/// name attribute
		/// </summary>
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return Convert.ToString(this["name"]); }
			set { this["name"] = value; }
		}

		/// <summary>
		/// value attribute, eg 'self'
		/// </summary>
		[ConfigurationProperty("value", IsKey = false, IsRequired = true)]
		public string Value
		{
			get { return Convert.ToString(this["value"]); }
			set { this["value"] = value; }
		}

		object IKey.Key
		{
			get { return this.Name; }
		}
	}

	#endregion

	#region Generic ConfigurationCollection

	public interface IKey
	{
		object Key { get; }
	}

	public class ConfigurationCollection<T> : ConfigurationElementCollection where T : ConfigurationElement, IKey, new()
	{
		public ConfigurationCollection()
		{
		}

		public override ConfigurationElementCollectionType CollectionType
		{
			get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
		}
		protected override ConfigurationElement CreateNewElement()
		{
			return new T();
		}
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((T)element).Key;
		}
		public T this[int index]
		{
			get { return (T)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
					BaseRemoveAt(index);

				BaseAdd(index, value);
			}
		}
		new public T this[string name]
		{
			get { return (T)BaseGet(name.ToLowerInvariant()); }
		}
		public int IndexOf(T element)
		{
			return BaseIndexOf(element);
		}
		public void Add(T element)
		{
			BaseAdd(element);
		}
		protected override void BaseAdd(ConfigurationElement element)
		{
			base.BaseAdd(element, false);
		}
		public void Remove(T element)
		{
			if (BaseIndexOf(element) > 0)
				BaseRemove(element.Key);
		}
		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}
		public void Remove(string type)
		{
			BaseRemove(type);
		}
		public void Clear()
		{
			BaseClear();
		}
	}

	#endregion
}