using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Enums
{
    /// <summary>
    /// The Type of notification which helps in updating the delivery status
    /// </summary>
    public enum DeliveryStatus
    {
        /// <summary>
        /// Pending for delivery.
        /// </summary>
        PENDING_DELIVERY,

        /// <summary>
        /// Delivered.
        /// </summary>
        DELIVERED,

        /// <summary>
        /// could not be delivered.
        /// </summary>
        COULD_NOT_DELIVER
    }
}