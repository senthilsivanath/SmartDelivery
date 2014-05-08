using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Web.Core.Enums;


namespace Tesco.Com.Web.Core.Models
{
    /// <summary>
    /// shipment (eg { get; set; } grocery web order) detailsRepository to be stored for delivery tracking. 
    /// </summary>
    public class Shipment
    {
        /// <summary>
        /// booking reference number (eg. UID, web orderID).
        /// </summary>
        public string bookingReferenceID { get; set; }
 
        /// <summary>
        /// planned time of delivery departure for shipment.
        /// </summary>
        public string plannedArrivalTime { get; set; }
 
        /// <summary>
        /// planned time of delivery arrival for shipment.
        /// </summary>
        public string plannedDepartureTime { get; set; }

        /// <summary>
        /// Latest estimated time of arrival for shipment.
        /// </summary>
        public string estimatedArrivalTime { get; set; }

        /// <summary>
        /// Actual time of arrival for shipment
        /// </summary>
        public string actualArrivalTime { get; set; }

        /// <summary>
        /// Delivery status for the shipment 
        /// </summary>
        public DeliveryStatus deliveryStatus { get; set; }

        /// <summary>
        /// Last updated time for this shipment.
        /// </summary>
        public string lastUpdatedTime { get; set; }

        /// <summary>
        ///Calculated slot delay time interval in hh:mm:ss. 
        /// </summary>
        public string slotDelay { get; set; }
    }
}