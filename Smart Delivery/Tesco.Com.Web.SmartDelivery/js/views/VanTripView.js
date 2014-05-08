YUI.add('vantrip-view', function (Y) {

    'use strict';

    Y.VanTripView = Y.Base.create('VanTripView', Y.View, [], {

        events: {

            '#btnStartDay': {

                click: function (e) {
                    this.triggerValidation();
                }
            },

            '#txtVantripId': {
                keypress: function (e) {

                    if (!this.spacialCharcterValidation(e.charCode)) {
                        e.preventDefault();
                    }

                    Y.one('#lblVanError').set('innerHTML', '');
                }
            },

            '#txtStoreID': {
                keypress: function (e) {

                    if (!this.spacialCharcterValidation(e.charCode)) {
                        e.preventDefault();
                    }

                    Y.one('#lblStoreError').set('innerHTML', '');
                }
            }
        },

        initializer: function () {

        },

        render: function () {
            var item = this;
            var response;
            Y.Helper.getTemplate('VanTrip', function (responseText) {
                response = responseText;
                item.get('container').setHTML(response);

            });

            return this;
        },

        Validation: function (input, bMessage) {

            var mes = "";

            if (input == '')
                mes = bMessage;

            return mes;
        },

        spacialCharcterValidation: function (key) {

            var sChar = String.fromCharCode(key);

            if (/[^a-zA-Z0-9\-\/]/.test(sChar)) {
                return false;
            }

            return true;
        },

        triggerValidation: function () {

            /* Blank space validation*/
            var message = this.Validation(Y.one('#txtVantripId').get('value'), Y.one('#txtVantripId').getAttribute('data-blankSpace'));

            if (message != "")
                Y.one('#lblVanError').set('innerHTML', message);


            message = this.Validation(Y.one('#txtStoreID').get('value'), Y.one('#txtStoreID').getAttribute('data-blankSpace'));

            if (message != "")
                Y.one('#lblStoreError').set('innerHTML', message);

            if (message == "") {

                /* Validate Vantrip Id, storeId */
                var vanTrip = this.get('model');

                Y.one('#divLoading').setStyle("display", "block");
                Y.one('#btnStartDay').set('disabled', true);

                vanTrip.load({ storeId: Y.one('#txtStoreID').get('value'), vanTripId: Y.one('#txtVantripId').get('value') }, function () {

                    Y.one('#divLoading').setStyle("display", "none");
                    Y.one('#btnStartDay').set('disabled', false);

                    if (vanTrip._state.data.vanTripDetails.value.Orders === null) {
                        Y.one('#lblVanError').set('innerHTML', Y.one('#txtStoreID').getAttribute('data-invalidCode'));
                    }
                    else {
                        Y.config.win.location = '#/signout'
                    }
                });
            }
        }
    });
}, '0.1', { requires: ['view', 'helper'] });

