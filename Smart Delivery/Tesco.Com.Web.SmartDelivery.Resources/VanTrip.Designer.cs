﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tesco.Com.Web.SmartDelivery.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class VanTrip {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal VanTrip() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tesco.Com.Web.SmartDelivery.Resources.VanTrip", typeof(VanTrip).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Store ID.
        /// </summary>
        public static string BlankStoreValidation {
            get {
                return ResourceManager.GetString("BlankStoreValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Van trip ID.
        /// </summary>
        public static string BlankVantripValidation {
            get {
                return ResourceManager.GetString("BlankVantripValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Smart Delivery System.
        /// </summary>
        public static string Heading {
            get {
                return ResourceManager.GetString("Heading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Van Trip ID or Store ID is incorrect.
        /// </summary>
        public static string InValidVantripValidation {
            get {
                return ResourceManager.GetString("InValidVantripValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Day.
        /// </summary>
        public static string StartDay {
            get {
                return ResourceManager.GetString("StartDay", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Store ID.
        /// </summary>
        public static string StoreID {
            get {
                return ResourceManager.GetString("StoreID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Van Trip ID.
        /// </summary>
        public static string VanTripId {
            get {
                return ResourceManager.GetString("VanTripId", resourceCulture);
            }
        }
    }
}
