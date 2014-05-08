YUI.add('admin-view', function (Y) {

    'use strict';

    Y.AdminView = Y.Base.create('AdminView', Y.View, [], {



        initializer: function () {

        },

        render: function () {
            var item = this;
            var response;
            Y.Helper.getTemplate('Admin', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
            });
            return this;



        }

    });

}, '0.1', { requires: ['view', 'helper'] });