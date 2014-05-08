YUI.add('accidentsupport-view', function (Y) {

    'use strict';

    Y.AccidentSupportView = Y.Base.create('AccidentSupportView', Y.View, [], {

        events: {

            
        },

        initializer: function () {
            var item = this;
            var response;
            Y.Helper.getTemplate('AccidentSupport', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
            });
        },

        render: function () {


            return this;
        }

    });

}, '0.1', { requires: ['view', 'helper'] });

