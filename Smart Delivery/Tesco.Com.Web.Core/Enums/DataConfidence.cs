using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Enums
{
    /// <summary>
    /// Data confidence on trip status and ETA.
    /// </summary>
    public enum DataConfidence
    {
        /// <summary>
        /// suggest high data confidence for trip status.
        /// </summary>
        HIGH,

        /// <summary>
        /// suggest medium data confidence for trip status.
        /// </summary>
        MEDIUM,

        /// <summary>
        /// suggest low data confidence for trip status.
        /// </summary>
        LOW
    }
}