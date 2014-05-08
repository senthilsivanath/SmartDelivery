using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesco.Com.Web.Core.Models
{
    public class VanTripDetails
    {
        public TripDetail TripDetails { get; set; }

        public List<Order> Orders { get; set; }

    }
}
