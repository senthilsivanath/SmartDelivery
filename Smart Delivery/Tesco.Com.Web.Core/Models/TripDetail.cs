using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Web.Core.Enums;

namespace Tesco.Com.Web.Core.Models
{
    /// <summary>
    /// Trip details to be stored for delivery tracking.
    /// </summary>
    public class TripDetail
    {
        /// <summary>
        /// Trip identifier.
        /// </summary>
        public string tripId { get; set; }

        /// <summary>
        /// Van trip name for identifying a trip.
        ///  </summary>\\n public
        public string tripName { get; set; }

        /// <summary>
        ///Planned time of trip start from store. 
        /// </summary>
        public DateTime plannedStartTime { get; set; }

        /// <summary>
        ///Actual time of trip start from store.
        /// </summary>/n public
        public DateTime actualStartTime { get; set; }

        /// <summary>
        ///Planned time of trip end.
        /// </summary>\n public
        public DateTime plannedEndTime { get; set; }

        /// <summary>
        /// Actual time of trip end.
        /// </summary>\n public
        public DateTime actualEndTime { get; set; }

        /// <summary>
        /// van registration number associated with trip.
        /// </summary>\\n public
        public string vanRegNo { get; set; }

        /// <summary>
        ///Status for a trip. 
        /// </summary>
       public TripStatus tripStatus { get; set; }

        /// <summary>
        ///driver name associated with the trip. 
        /// </summary>
        public string driverName { get; set; }

        /// <summary>
        ///driver badge id associated with the trip. 
        /// </summary>
        public string driverBadgeId { get; set; }

        /// <summary>
        ///driver contact number associated with the trip. 
        /// </summary>
        public string driverContactNumber { get; set; }

        /// <summary>
        /// shipments associated with the trip.
        /// </summary>
        public List<Shipment> shipments { get; set; }

        /// <summary>
        /// Identify the trip type like delivery or collect from location.
        /// </summary>
        public ServiceType serviceType { get; set; }

        /// <summary>
        /// location identifier for which trip belongs.
        /// </summary>
        public string locationId { get; set; }

        /// <summary>
        /// Capture any notes for the trip like breakdown, delay due to traffic jam etc.
        /// This data will be used by CSA while resolving customer query.
        /// </summary>
        public string trackingNotes { get; set; }

        /// <summary>
        /// Departure delay time interval for van trip in hh:mm:ss.
        /// </summary>
        public DateTime departureDelay { get; set; }

        /// <summary>
        ///Data confidence of the van trip information. 
        /// </summary>
        public DataConfidence tripDataConfidence { get; set; }
    }
}