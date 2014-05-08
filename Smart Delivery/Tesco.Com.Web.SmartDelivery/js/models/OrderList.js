YUI.add('order-list', function (Y) {

    'use strict';


    Y.OrderList = Y.Base.create('OrderList', Y.ModelList, [], {
        model: Y.Order,

        initialize : function(){
            alert('I am here');
        },

        // Returns an array of OrderModel instances that are pending.
        pendingOrders: function () {
            return Y.Array.filter(this.toArray(), function (model) {
                return model.get('deliveryStatus') === 0;
            });
        },
        // Returns an array of OrderModel instances that are delivered.
        deliveredOrders: function () {
            return Y.Array.filter(this.toArray(), function (model) {
                return model.get('deliveryStatus') === 1;
            });
        },
        // Returns an array of OrderModel instances that are delivered.
        undeliveredOrders: function () {
            return Y.Array.filter(this.toArray(), function (model) {
                return model.get('deliveryStatus') === 2;
            });
        },
        // By default all orders are not synced, when the sync succeeds, isSync is changed to true
        unsyncedOrders: function () {
            return Y.Array.filter(this.toArray(), function (model) {
                return model.get('isSynced') === false;
            });
        },
        // Synces all unsynced models to server
        syncOrders: function () {
            Y.Array.each(unsyncedOrders(), function (model) {
                model.save();
            });
        }
    });

}, '0.1', { requires: ['model-list', 'order', 'model-sync-rest', 'gallery-storage-lite'] });