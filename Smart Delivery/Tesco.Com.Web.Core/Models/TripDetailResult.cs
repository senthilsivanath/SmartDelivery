using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Models
{
    /// <summary>
    /// The entity that defines the Trip Details result.
    /// </summary>
    public class TripDetailResult
    {
        /// <summary>
        /// The paged list containing matching TripDetail entities.
        /// </summary>
        public List<TripDetail> resultSubSet { get; set; }

        /// <summary>
        /// The total count of matching results.
        /// </summary>
        public int totalMatchedCount { get; set; }
    }
}