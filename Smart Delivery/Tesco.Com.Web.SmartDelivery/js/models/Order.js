YUI.add('order', function (Y) {

    'use strict';

    Y.Order = Y.Base.create('Order', Y.Model, [], {
        root: '',
        // Save method of model fires this event, can be used for update order status
        sync: function (action, options, callback) { 
               
        }

    }, {
        ATTRS: {
            isSynced: {
                value: false
            }
        }
    });

}, '0.1', { requires: ['io-base', 'model'] });
