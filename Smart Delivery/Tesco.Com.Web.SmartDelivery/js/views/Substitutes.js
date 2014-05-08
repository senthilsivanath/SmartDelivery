YUI.add('substitute-view', function (Y) {

    'use strict';

    Y.SubstituteView = Y.Base.create('SubstituteView', Y.View, [], {

        events: {

            '#btnSave': {

                click: function (e) {

                }
            },

            '#btnCancel': {

                click: function (e) {

                }
            }
        },

        initializer: function () {

            var item = this;
            var response;

            Y.Helper.getTemplate('Substitutes', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);

                var curScroll = item.CreateSubstituteBody(item);

                var scrollview = new Y.ScrollView({
                    id: "scrollsubstitue",
                    srcNode: '#tblSubstitute',
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
            });
        },

        render: function () {
            return this;
        },

        FilterOrderLine: function (orderId) {

            var data = Y.StorageLite.getItem('vanTrip', true) || [];
            var orderLines;

            Y.Array.some(data.vanTripDetails.Orders, function (order) {

                if (order.CustomerOrderReference == orderId.toString()) {
                    orderLines = order.Orderlines;
                    return orderLines;
                }
            });

            return orderLines;
        },

        GetOrderId: function () {
            var orderId = Y.Helper.getQueryVariable(window.location.href, 'orderId');
            return orderId;
        },

        RedirectSubstitute: function () {

        },

        CreateSubstituteBody: function (item) {

            var row = '';
            var sub = '';

            var quanHeading = Y.one('#lblQuantity').get('innerHTML');
            var subHeading = Y.one('#lblSubstitute').get('innerHTML');

            var orderId = item.GetOrderId();

            //[Set heading]
            var heading = Y.one('#hSubstituteId').get('innerHTML') + ": " + orderId;
            Y.one('#hSubstituteId').set('innerHTML', heading);

            var orderLines = item.FilterOrderLine(orderId);

            if (orderLines == undefined)
                return;


            var tr, td, divOne, divTwo, divThree, divFour, span, spanOne, spanTwo, img, spanThree, spanFour;


            Y.Array.each(orderLines, function (order) {

                if (order.IsSubstitued)
                    sub = "Yes";
                else
                    sub = "No";

                tr = document.createElement('tr');
                td = document.createElement('td');
                td.className = 'totalwidth';

                divOne = document.createElement('div');
                divOne.className = 'totalwidth';

                span = document.createElement('span');
                span.innerHTML = order.Description;
                divOne.appendChild(span);
                td.appendChild(divOne);
                tr.appendChild(td);

                divTwo = document.createElement('div');
                divTwo.className = 'totalwidth';
                td.appendChild(divTwo);

                divThree = document.createElement('div');
                divThree.className = 'customer-detailsleft';
                divTwo.appendChild(divThree);

                spanOne = document.createElement('span');
                spanOne.className = 'gridspanspace';
                spanOne.innerHTML = "<b>" + quanHeading + "</b>";
                divThree.appendChild(spanOne);

                spanTwo = document.createElement('span');
                spanTwo.className = 'gridsubrightspace';
                spanTwo.innerHTML = order.PickedQuantity;
                divThree.appendChild(spanTwo);


                spanThree = document.createElement('span');
                spanThree.className = 'gridspanspace';
                spanThree.innerHTML = "<b>" + subHeading + "</b>";
                divThree.appendChild(spanThree);

                spanFour = document.createElement('span');
                spanFour.innerHTML = sub;
                divThree.appendChild(spanFour);

                divFour = document.createElement('div');
                divFour.className = 'customer-detailsleft customer-textalign';
                divTwo.appendChild(divFour);

                img = document.createElement('img');
                img.className = 'icon';
                img.src = '/images/substitute.png';
                img.width = '16';
                img.height = '16';
                img.style.cursor = 'pointer';

                img.onclick = function () {
                    item.RedirectSubstitute();
                }

                divFour.appendChild(img);
                Y.one('#tblSubstitute').appendChild(tr);
            });
        }
    });

}, '0.1', { requires: ['view', 'helper', 'scrollview-base'] });

