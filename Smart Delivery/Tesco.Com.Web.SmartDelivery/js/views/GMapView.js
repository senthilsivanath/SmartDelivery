
YUI.add('gmap-view', function (Y) {

    'use strict';
    Y.GMapView = Y.Base.create('gmapview', Y.View, [], {

        initializer: function () {

        },
        render: function () {
            var item = this;
            var request = Y.io("/SmartDelivery/UIAssets/js/UI/smartdelivery/views/templates/GMap.html", {
                on: {

                    complete: function (id, response) {

                        var template = Y.Handlebars.compile(response.responseText);
                        item.get('container').setHTML(template());

                        navigator.geolocation.watchPosition(function (position) {
                            fnLoadGoogleMap(position, Y);
                        });
                    }
                }
            });
            return this;
        }

    });

}, '0.1', { requires: ['view', 'node', 'json', 'json - stringify', 'handlebars', 'gallery-google-maps-loader'] });

fnLoadGoogleMap = function (position,Y) {

    new Y.GoogleMapsLoader().load({
        language: 'en',
        libraries: [
                        'adsense',
                        'geometry'
                    ],
        region: 'ES',
        sensor: false,
        version: '3.4'
    }).on('success', function () {

        var directionsDisplay = new google.maps.DirectionsRenderer();
        var directionsService = new google.maps.DirectionsService();
        var currentLoc = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

        var mapOptions = {
            zoom: 18,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            center: currentLoc
        }
        var map = new google.maps.Map(Y.Node.getDOMNode(Y.one('#mapContainer')), mapOptions);
        directionsDisplay.setMap(map);

        var start = 'London';
        var end = 'bristol';
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });

    });
}
