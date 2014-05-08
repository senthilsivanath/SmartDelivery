YUI.add('van-trip', function (Y) {

    'use strict';

    Y.VanTrip = Y.Base.create('VanTrip', Y.Model, [], {

        root: '/Home/ValidateVantripStoreId',

        sync: function (action, options, callback) {


            var data, err = null;
            if (action === 'read') {

                data = Y.StorageLite.getItem('vanTrip', true) || [];


                if (data.length === 0) {
                    this._loadlist(options, callback);
                }
                else {
                    if (Y.Lang.isFunction(callback)) {
                        callback(err, data);
                    }
                }
            }
            else {
                err = 'Invalid action';
            }

        },
        _loadlist: function (data, callback) {


            var err = '';
            var request = Y.io(this.root, {
                method: 'GET',
                data: data,
                on: {
                    complete: function (id, response) {
                        var data = response.responseText;

                        if (Y.Lang.isFunction(callback)) {
                            var dataJSON = Y.JSON.parse(data);
                            if (dataJSON.vanTripDetails.TripDetails != null) {
                                Y.StorageLite.setItem('vanTrip', data);
                            }
                            callback(err, data);
                        }
                    }
                }
            });
        }

    });

}, '0.1', { requires: ['io-base', 'model'] });
