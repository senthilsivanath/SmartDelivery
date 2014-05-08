using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Models
{

    public class Order
    {

        /// <summary>
        /// Order Number.
        /// </summary>

        public int CustomerOrderId { get; set; }


        /// <summary>
        /// Order Number.
        /// </summary>

        public string CustomerOrderReference { get; set; }

        /// <summary>
        /// Order Number.
        /// </summary>

        public int ShortOrderNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string WindowStartDateString { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string WindowEndDateString { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string GridReference { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public DateTime ScheduledArrival { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int AmbientTrayCount { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int ChilledTrayCount { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int FrozenTrayCount { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int WineTrayCount { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int DirectParcelCount { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public Customer Customer { get; set; }
        /// <summary>
        /// DeliveryInstructions
        /// </summary>
        public string DeliveryNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string DeliverySlot { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public bool DeliveryWithoutBags { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public OrderLines[] Orderlines { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public bool CustomerDeliveryStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int DropSequence { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public DateTime DropTime { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int TotalItems { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public double SubTotalAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public double Discounts { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int TotalSubstitutedItems { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int TotalOffsaledItems { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string StoreMessage { get; set; }

    }
}