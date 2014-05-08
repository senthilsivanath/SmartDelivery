YUI.add('orderdetail-view', function (Y) {

    'use strict';

    Y.OrderDetailView = Y.Base.create('OrderDetailView', Y.View, [], {

        events: {


        },

        initializer: function () {
            var item = this;
            var response;
            Y.Helper.getTemplate('OrderDetail', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
                item.RenderResource();
            });
        },

        render: function () {
            return this;
        },
        // Filter the order by short order number
        GetOrderByOrderId: function (orders, OrderId) {
            var orderResult = '';
            for (var index = 0; index < orders.length; index++) {
                if (orders[index].CustomerOrderReference == parseInt(OrderId)) {
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
            var OrderId = Y.Helper.getQueryVariable(window.location.href.toString(), 'OrderId');

            var order = this.GetOrderByOrderId(orders, OrderId);
            var shipment = this.GetShipment(Shipments, order.CustomerOrderReference);
            var date = new Date(Date.parse(order.DropTime));
            Y.one('#strOrderNumber').set('innerHTML', OrderId);
            Y.one('#spnCustomerName').set('innerHTML', order.Customer.CustomerFullName);
            Y.one('#spnCustomerAddress').set('innerHTML', order.Customer.Address);
            Y.one('#strTotal_Items').set('innerHTML', order.TotalItems);
            Y.one('#strSub_Total').set('innerHTML', order.SubTotalAmount);
            Y.one('#strDiscount').set('innerHTML', order.Discounts);
            Y.one('#strTotal').set('innerHTML', 'NA');
            Y.one('#strSubstitutes').set('innerHTML', order.TotalSubstitutedItems);
            Y.one('#strShort_Life').set('innerHTML', 'NA');

        },
        initializeMap: function () {

        }

    });

}, '0.1', { requires: ['view', 'helper'] });

