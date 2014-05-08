using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Enums
{
    /// <summary>
    /// The Type of service for which a slot is being booked.
    /// </summary>
    public enum ServiceType
    {
        /// <summary>
        /// Ship to customer address via store van delivery.
        /// </summary>
        DOTCOM_VAN_DELIVERY,

        /// <summary>
        /// Customer will pickup from chosen collection point.
        /// </summary>
        CLICK_AND_COLLECT,

        /// <summary>
        /// Van trip that contain unrouted trips.
        /// </summary>
        UNROUTED,

        /// <summary>
        /// Van trip that is created in store.
        /// </summary>
        ADHOCTRIP
    }
}