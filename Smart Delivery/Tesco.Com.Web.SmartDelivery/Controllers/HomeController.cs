
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Tesco.Com.Web.Core.Models;
using System.Linq;
using System.Reflection;
using log4net;

namespace Tesco.Com.Web.SmartDelivery.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            log.Error("This is first message from log");
            string langauge = "en";

            if (ControllerContext.RouteData.Values.ContainsKey("culture"))
            {
                langauge = ControllerContext.RouteData.Values["culture"].ToString();
            }

            ViewBag.Language = langauge;
            return View();
        }

        [HttpGet]
        public JsonResult ValidateVantripStoreId(string vanTripId, string storeId)
        {
            var responseText = ReadJsonResult(vanTripId, storeId);

            VanTripDetails vanTripDetails = TransformToSingleModel(responseText);

            return Json(new { vanTripDetails }, JsonRequestBehavior.AllowGet);
        }

        private string ReadJsonResult(string vanTripId, string storeId)
        {
            var responseText = string.Empty;

            string transportServiceURL = ConfigurationManager.AppSettings["transportServiceURL"];
            transportServiceURL += "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/" + storeId + "/?filter=VanTripId:" + vanTripId;

            var httpWebRequest = WebRequest.Create(transportServiceURL) as HttpWebRequest;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";


            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }

            return responseText;
        }

        private VanTripDetails TransformToSingleModel(string responseText)
        {
            TripDetailResult tripDetails = null;
            string[] orderIds = null;
            List<OrderService.Order> orders = null;

            VanTripDetails vanTripDetails = new VanTripDetails();

            if (!responseText.Equals(""))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                tripDetails = serializer.Deserialize<TripDetailResult>(responseText);
            }

            #region OrderAppStore Service Call

            if (tripDetails != null && tripDetails.totalMatchedCount > 0)
            {
                orderIds = tripDetails.resultSubSet.Select(x => new { orderId = x.shipments.Select(y => y.bookingReferenceID).ToArray() }.orderId).Single();

                using (OrderService.AppStoreOrderClient client = new OrderService.AppStoreOrderClient())
                {
                    orders = client.GetCustomerOrderInfo(orderIds).ToList();
                }
            }
            else
            {
                return vanTripDetails;
            }

            #endregion

            #region Convert Model

            vanTripDetails.TripDetails = tripDetails.resultSubSet.Select(x => x).SingleOrDefault();
            vanTripDetails.TripDetails.shipments.All(x =>
            {
                x.estimatedArrivalTime = GetTime(x.estimatedArrivalTime);
                x.actualArrivalTime = GetTime(x.actualArrivalTime);
                x.lastUpdatedTime = GetTime(x.lastUpdatedTime);
                x.plannedArrivalTime = GetTime(x.plannedArrivalTime);
                x.plannedDepartureTime = GetTime(x.plannedDepartureTime);
                x.slotDelay = GetTime(x.slotDelay);
                return true;
            });

            vanTripDetails.Orders = new List<Order>();

            orders.ForEach(x =>
            {
                vanTripDetails.Orders.Add(new Order()
                {
                    CustomerOrderId = x.CustomerOrderId,
                    CustomerOrderReference = x.CustomerOrderReference,
                    ShortOrderNumber = x.ShortOrderNumber,
                    WindowStartDateString = x.WindowStart.ToString("HH:mm"),
                    WindowEndDateString = x.WindowEnd.ToString("HH:mm"),
                    GridReference = x.GridReference,
                    ScheduledArrival = x.ScheduledArrival,
                    AmbientTrayCount = x.AmbientTrayCount,
                    ChilledTrayCount = x.ChilledTrayCount,
                    FrozenTrayCount = x.FrozenTrayCount,
                    WineTrayCount = x.WineTrayCount,
                    DirectParcelCount = x.DirectParcelCount,
                    Customer = new Customer
                    {
                        CustomerTitle = x.Customer.CustomerTitle,
                        CustomerSurname = x.Customer.CustomerSurname,
                        Address = x.Customer.Address,
                        Postcode = x.Customer.Postcode,
                        PhoneDaytime = x.Customer.PhoneDaytime,
                        PhoneEvening = x.Customer.PhoneEvening,
                        PhoneMobile = x.Customer.PhoneMobile,
                        CustomerFullName = x.Customer.CustomerFullName,
                        SignaturePoints = x.Customer.SignaturePoints.ToArray(),
                        customerCommunication = new CustomerCommunication
                        {
                            ID = x.Customer.customerCommunication.ID,
                            CommunicationTime = x.Customer.customerCommunication.CommunicationTime,
                            CommunicationDetail = x.Customer.customerCommunication.CommunicationDetail
                        },
                    },

                    DeliveryNotes = x.DeliveryNotes,
                    DeliverySlot = x.DeliverySlot,
                    DeliveryWithoutBags = x.DeliveryWithoutBags,
                    Orderlines = x.Orderlines.Select(y => new OrderLines
                    {
                        OrderLineId = y.OrderLineId,
                        Barcode = y.Barcode,
                        Description = y.Description,
                        PickedQuantity = y.PickedQuantity,
                        IsSubstitued = y.IsSubstitued,
                        SubstitutedFor = y.SubstitutedFor,
                        RejectedQuantity = y.RejectedQuantity,
                        RejectionReason = (RejectionReason)Enum.ToObject(typeof(RejectionReason), y.RejectionReason),
                        UnitPrice = y.UnitPrice
                    }).ToArray(),

                    CustomerDeliveryStatus = x.CustomerDeliveryStatus,
                    DropSequence = x.DropSequence,
                    DropTime = x.DropTime,
                    TotalItems = x.TotalItems,
                    SubTotalAmount = x.SubTotalAmount,
                    Discounts = x.Discounts,
                    TotalSubstitutedItems = x.TotalSubstitutedItems,
                    TotalOffsaledItems = x.TotalOffsaledItems,
                    StoreMessage = x.StoreMessage

                });

            });

            #endregion

            return vanTripDetails;
        }

        [NonActionAttribute]
        private string GetTime(string property)
        {
            return (DateTime.Parse(property)).ToString("HH:mm");
        }
    }
}
