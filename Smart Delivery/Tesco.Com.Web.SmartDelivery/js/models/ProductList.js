YUI.add('product-list', function (Y) {

    'use strict';


    Y.ProductList = Y.Base.create('ProductList', Y.ModelList, [], {
        model: Y.Product,
        // Returns an array of ProductModel instances that have been substituted.
        substitutedProducts: function () {
            return Y.Array.filter(this.toArray(), function (model) {
                return model.get('IsSubstitued') === true;
            });
        },

        // Returns an array of ProductModel instances that are rejected.
        rejectedProducts: function () {
            return Y.Array.filter(this.toArray(), function (model) {
                return model.get('RejectedQuantity') > 0;
            });
        }
    });

}, '0.1', { requires: ['model-list', 'product', 'model-sync-rest', 'gallery-storage-lite'] });