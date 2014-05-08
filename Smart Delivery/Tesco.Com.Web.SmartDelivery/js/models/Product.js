YUI.add('product', function (Y) {

    'use strict';

    Y.Product = Y.Base.create('Product', Y.Model, [], {
        root: ''

    });

}, '0.1', { requires: ['io-base', 'model'] });
