YUI({
    base: fnBase(),
    root: 'yui_3.12.0/yui/build/',
    combine: true,
    comboBase: fnCombo(),
    modules: {
        'helper': {
            path: "helpers/Helper.js"
        },
        'home-view': {
            path: "views/HomeView.js"
        },
        'vantrip-view': {
            path: "views/VanTripView.js"
        },
        'admin-view': {
            path: "views/AdminView.js"
        },
        'signout-view': {
            path: "views/SignOutView.js"
        },
        'ordergrid-view': {
            path: "views/OrderGridView.js"
        },
        'training-view': {
            path: "views/TrainingView.js"
        },
        'navigation-view': {
            path: "views/NavigationView.js"
        }, 
        'orderdetail-view': {
            path: "views/OrderDetailView.js"
        },
        'accidentsupport-view': {
            path: "views/AccidentSupportView.js"
        },
        'order': {
            path: "models/Order.js"
        },
        'order-list': {
            path: "models/OrderList.js"
        },
        'van-trip': {
            path: "models/VanTrip.js"
        },
        'substitute-view': {
            path: "views/Substitutes.js"
        }
    },
    global: {
        templates: fnTemplate()
    }
}).use('app-base', 'router', 'helper', 'home-view', 'vantrip-view', 'admin-view', 'navigation-view', 'orderdetail-view' ,'accidentsupport-view',
        'vantrip-view', 'signout-view', 'ordergrid-view', 'training-view', 'order', 'order-list', 'van-trip',
        'substitute-view',
       function (Y) {

           'use strict';

           var app;

           var vanTrip = new Y.VanTrip();

           app = new Y.App({
               transitions: false,
               root: fnRoot(),
               html5: false,
               viewContainer: '#content',

               views: {
                   homeView: {
                       type: 'HomeView'
                   },
                   vantripView: {
                       type: 'VanTripView',
                       parent: 'homeView'
                   },
                   adminView: {
                       type: 'AdminView',
                       parent: 'homeView'
                   },
                   trainingView: {
                       type: 'TrainingView',
                       parent: 'homeView'
                   },
                   signoutView: {
                       type: 'SignOutView',
                       parent: 'homeView'
                   },
                   ordergridView: {
                       type: 'OrderGridView',
                       parent: 'homeView'
                   },
                   navigationView: {
                       type: 'NavigationView',
                       parent: 'homeView'
                   },
                   orderdetailView: {
                       type: 'OrderDetailView',
                       parent: 'homeView'
                   },
                   accidentsupportView: {
                       type: 'AccidentSupportView',
                       parent: 'homeView'
                   },
                   substituteView: {
                       type: 'SubstituteView',
                       parent: 'homeView'
                   }
               },
               routes: [
                    {
                        path: '*',
                        callback: function (e) {
                            if (e.url.lastIndexOf('vantrip') != -1) {
                                this.showView('vantripView', { model: vanTrip });
                            }
                            else if (e.url.lastIndexOf('admin') != -1) {
                                this.showView('adminView');
                            }
                            else if (e.url.lastIndexOf('training') != -1) {
                                this.showView('trainingView');
                            }
                            else if (e.url.lastIndexOf('signout') != -1) {
                                this.showView('signoutView');
                            }
                            else if (e.url.lastIndexOf('ordergrid') != -1) {
                                this.showView('ordergridView');
                            }
                            else if (e.url.lastIndexOf('navigation') != -1) {
                                this.showView('navigationView');
                            }
                            else if (e.url.lastIndexOf('orderdetail') != -1) {
                                this.showView('orderdetailView');
                            }
                            else if (e.url.lastIndexOf('accidentsupport') != -1) {
                                this.showView('accidentsupportView');
                            }
                            else if (e.url.lastIndexOf('substitute') != -1) {
                                this.showView('substituteView');
                            }
                            else {
                                this.showView('homeView');
                            }
                        }
                    }
              ]
           });

           app.navigate(app._url);
       });

function fnRoot() {
    var item = window.location.pathname.split('/');

    return item[0];
}

function fnBase() {
    var item = window.location.pathname.split('/');
    var value = item[0] + "/js/";

    return value;
}
function fnCombo() {
    var item = window.location.pathname.split('/');
    var value = item[0] + "/dummy.combo?";
    return value;
}

function getLanguage() {
    var path = window.location.pathname;

    var language = "";

    if (path == '/') {
        language = "en";
    }
    else {

        var test = path.match(/.*\/(.*)\//);
        language = test[1];
    }
    return language;
}
function fnTemplate() {


    value = "/" + getLanguage() + '/Template/';

    return value;
}

