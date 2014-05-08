YUI.add('home-view', function (Y) {

    'use strict';

    Y.HomeView = Y.Base.create('HomeView', Y.View, [], {



        initializer: function () {
           
        },

        render: function () {
            
            var item = this;
            var response;
           

            Y.Helper.getTemplate('Index', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
               
            });
            return this;

        }

    });

}, '0.1', { requires: ['view', 'helper', 'order-list'] });