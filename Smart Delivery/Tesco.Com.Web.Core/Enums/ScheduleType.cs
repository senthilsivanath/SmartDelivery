using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Enums
{
    /// <summary>
    /// The schedule type which can be draft and final.
    /// </summary>
    public enum ScheduleType
    {
        /// <summary>
        /// suggest draft trip schedule.
        /// </summary>
        DRAFT,

        /// <summary>
        /// uggest final trip schedule.
        /// </summary>
        FINAL
    }
}