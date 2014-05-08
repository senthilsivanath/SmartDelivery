YUI.add('ordergrid-view', function (Y) {

    'use strict';

    Y.OrderGridView = Y.Base.create('OrderGridView', Y.View, [], {

        events: {
            
        },

        initializer: function () {

            var item = this;
            var response;
            Y.Helper.getTemplate('OrderGrid', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);

                var curScroll = item.CreateBody(item);

                var scrollview = new Y.ScrollView({
                    id: "scrollview",
                    srcNode: '#tblOrderGrid',
                    height: 310,
                    flick: {
                        minDistance: 10,
                        minVelocity: 0.3,
                        axis: "y"
                    }
                });
                scrollview.render();

                var content = scrollview.get("contentBox");

                //[subscribe to event]
                content.on("mousewheel", function (e) {

                    Y.Helper.scrollEvent(scrollview, 0, e);

                    e.preventDefault();
                });

                //[Auto scroll]
                Y.Helper.scrollEvent(scrollview, curScroll);
            });
        },

        render: function () {
            return this;
        },

        fetchDeliveryStatus: function (shipments, orderId) {

            var status = 0;

            for (var index = 0; index < shipments.length; index++) {

                if (shipments[index].bookingReferenceID == orderId) {

                    status = shipments[index].deliveryStatus
                    break;
                }
            }
            return status;
        },

        CreateBody: function (item) {

            var row = '';
            var data = Y.StorageLite.getItem('vanTrip', true) || [];
            var rowNo = 0;

            var orderHeading = Y.one('#lblOrderId').get('innerHTML');
            var slotHeading = Y.one('#lblSlotId').get('innerHTML');

            //[Set heading]
            var heading = Y.one('#h1Id').get('innerHTML') + " " + data.vanTripDetails.TripDetails.locationId;
            Y.one('#h1Id').set('innerHTML', heading);

            var shipments = data.vanTripDetails.TripDetails.shipments;
            var status = 0;
            var isFirst = 0;
            var imagePath = "";

            var scrollPosition = 47.5;
            var curScroll = 0;
            var cssClass = "";
            var orderPath = "";

            Y.Array.each(data.vanTripDetails.Orders, function (order, index) {

                rowNo = index + 1;

                status = item.fetchDeliveryStatus(shipments, order.CustomerOrderReference);

                if (status == 0) {
                    imagePath = '/images/Pending.png';
                }
                else if (status == 1) {
                    imagePath = '/images/Delivered.png';
                }
                else {
                    imagePath = '/images/NotSysn.png';
                }

                if (status == 0 && isFirst == 0) {

                    isFirst = 1;
                    curScroll = scrollPosition * rowNo;

                    cssClass = '';
                    orderPath = "<a href='#/navigation?OrderNumber=" + order.ShortOrderNumber + "&Sequence=" + rowNo + "'>" + order.ShortOrderNumber + "</a>";
                }
                else {
                    cssClass = "class='disablerow'";
                    orderPath = order.ShortOrderNumber;
                }

                row += "<tr " + cssClass + ">" +
                            "<td class='totalwidth'>" +
                                "<div class='customer-detailsleft'>" +
                                   "<span class='gridspanleft gridspanspace'>"
                                        + rowNo +
                                   ".</span>" +
                                   "<span>"
                                        + order.Customer.CustomerFullName +
                                   "</span>" +
                                "</div>" +
                                "<div class='customer-detailsleft customer-textalign'>" +
                                    "<span class='gridspanspace'>" +
                                        "<img class='icon' width='16' height='16' src='/images/phonecall.png' />" +
                                    "</span>" +
                                   "<span>" +
                                        "<img class='icon' src='" + imagePath + "' />" +
                                   "</span>" +
                                "</div>" +
                                "<div class='totalwidth'>" +
                                    "<span class='gridspanleft gridspanspace'>" +
                                        "<b>" + orderHeading + "</b>" +
                                    "</span>" +
                                    "<span class='gridtextrightspace'>"
                                        + orderPath +
                                    "</span>" +
                                    "<span class='gridspanspace'>" +
                                        "<b>" + slotHeading + "</b>" +
                                    "</span>" +
                                    "<span class='gridtextrightspace'>"
                                        + order.DeliverySlot +
                                    "</span>" +
                                    "<span class='gridspanspace'>" +
                                        "<img class='icon' src='/images/slottime.png' />" +
                                    "</span>" +
                                    "<span>"
                                        + order.WindowStartDateString +
                                    "</span>" +
                                "</div>" +
                           "</td>" +
                      "</tr> ";

                index++;
            });

            Y.one('#tblOrderGrid').appendChild('<tbody>' + row + '</tbody>');

            return curScroll;
        }


    });

}, '0.1', { requires: ['view', 'helper', 'scrollview-base'] });




