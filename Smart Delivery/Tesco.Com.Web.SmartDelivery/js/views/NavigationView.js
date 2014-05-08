YUI.add('navigation-view', function (Y) {

    'use strict';

    Y.NavigationView = Y.Base.create('NavigationView', Y.View, [], {

        events: {


        },

        initializer: function () {
            var item = this;
            var response;
            Y.Helper.getTemplate('Navigation', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
                //item.RenderResource(item.GetOrderByShortOrderNumber(Y.StorageLite.getItem('vanTrip', true) || [], Y.Helper.getQueryVariable('OrderNumber')));
                item.RenderResource();
            });
        },

        render: function () {
            return this;
        },
        // Filter the order by short order number
        GetOrderByShortOrderNumber: function (orders, shortOrderNumber) {
            var orderResult = '';
            for (var index = 0; index < orders.length; index++) {
                if (orders[index].ShortOrderNumber == parseInt(shortOrderNumber)) {
                    orderResult = orders[index];
                    break;
                }
            };

            return orderResult;
        },

        //Filter shipment details.
        GetShipment: function (shipments, orderId) {

            var shipment = '';
            for (var index = 0; index < shipments.length; index++) {
                if (shipments[index].bookingReferenceID == orderId) {
                    shipment = shipments[index];
                    break;
                }
            }
            return shipment;
        },

        RenderResource: function () {

            var data = Y.StorageLite.getItem('vanTrip', true) || [];
            var orders = data.vanTripDetails.Orders;
            var Shipments = data.vanTripDetails.TripDetails.shipments;
            var shortOrderNumber = Y.Helper.getQueryVariable(window.location.href.toString(), 'OrderNumber');
            var orderSequence = Y.Helper.getQueryVariable(window.location.href.toString(),'Sequence');

            var order = this.GetOrderByShortOrderNumber(orders, shortOrderNumber);
            var shipment = this.GetShipment(Shipments, order.CustomerOrderReference);
            var date = new Date(Date.parse(order.DropTime));
            Y.one('#spnAddress').set('innerHTML', order.Customer.Address);
            Y.one('#lnkOrderDetail').set('href', '\orderdetail?OrderId=' + order.CustomerOrderReference + '');
            Y.one('#spnJourneyTime').set('innerHTML','0:20');
            Y.one('#spnETA').set('innerHTML', shipment.estimatedArrivalTime);
            Y.one('#spnOrderSequence').set('innerHTML', orderSequence);
            Y.one('#spnTotalCount').set('innerHTML', orders.length);

        },
        initializeMap: function () {
            
        }

    });

}, '0.1', { requires: ['view', 'helper'] });

