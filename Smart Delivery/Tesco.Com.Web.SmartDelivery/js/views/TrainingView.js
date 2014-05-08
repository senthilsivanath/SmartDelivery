YUI.add('training-view', function (Y) {

    'use strict';

    Y.TrainingView = Y.Base.create('TrainingView', Y.View, [], {



        initializer: function () {

        },

        render: function () {
            var item = this;
            var response;
            Y.Helper.getTemplate('Training', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);
            });
            return this;



        }

    });

}, '0.1', { requires: ['view', 'helper'] });