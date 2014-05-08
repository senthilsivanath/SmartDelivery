YUI.add('signout-view', function (Y) {

    'use strict';

    Y.SignOutView = Y.Base.create('SignOutView', Y.View, [], {

        events: {

            '#btnSignOut': {
                click: function (e) {
                     Y.config.win.location = '#/ordergrid';
                }
            }
        },

        initializer: function () {

        },

        render: function () {

            var item = this;
            var response;
            Y.Helper.getTemplate('SignOut', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
            });

            var vantrip = this.get('model');

            return this;
        }

    });

}, '0.1', { requires: ['view', 'helper'] });

