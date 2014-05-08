using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Enums
{
    /// <summary>
    /// The Type of status for each trip which helps in updating the Trip information.
    /// </summary>
    public enum TripStatus
    {
        /// <summary>
        /// Specifies that Trip has not started.
        /// </summary>
        NOTSTARTED, 

        /// <summary>
        /// Specifies that Trip has been modified.
        /// </summary>
        MODIFIED,

        /// <summary>
        /// Specifies that the Trip has started.
        /// </summary>
        STARTED,

        /// <summary>
        /// Specifies that the Trip has Ended.
        /// </summary>
        ENDED,

        /// <summary>
        /// Specifies that the Trip is Ready for delivery.
        /// </summary>
        READY_FOR_DELIVERY,

        /// <summary>
        /// Specifies that Trip has been deleted.
        /// </summary>
        CANCELLED, 

        /// <summary>
        /// Specifies that the shipments in this trip are being done out of sequence.
        /// </summary>
        OUTOFSEQUENCE,

        /// <summary>
        /// Specifies that the trip tracking is inconsistent.
        /// </summary>
        INCONSISTENT,

        /// <summary>
        /// Specifies that the trip is not trackable.
        /// </summary>
        NOT_TRACKABLE,

        /// <summary>
        /// Specifies that the trip is aborted.
        /// </summary>
        ABORTED
    }
}