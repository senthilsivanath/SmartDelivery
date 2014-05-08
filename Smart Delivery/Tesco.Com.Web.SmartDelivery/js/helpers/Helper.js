YUI.add('helper', function (Y) {

    'use strict';


    function Helper() {

    }

    Helper.getTemplate = function (templateName, callback) {
        window.Handlebars = Y.Handlebars;
        Y.Get.js(Y.config.global.templates + templateName, function (err) {
            if (err) {
                Y.error('Template failed to load: ' + err);
                return;
            }
            callback(template());

        });
    };

    Helper.localKey = "orders";

    Helper.getQueryVariable = function (url, variable) {
        var varsFilter = url.split('?');
        var vars = varsFilter[1].split('&');
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split('=');
            if (decodeURIComponent(pair[0]) == variable) {
                return decodeURIComponent(pair[1]);
            }
        }
    };

    Helper.scrollEvent = function (scrollview, scroll_end, e) {

        var scroll_modifier = 10;
        var current_scroll_y, scroll_to;

        if (scroll_end == 0) {

            current_scroll_y = scrollview.get('scrollY');
            scroll_to = current_scroll_y - (scroll_modifier * e.wheelDelta);

            if (scroll_to <= scrollview._minScrollY) {

                scrollview._uiDimensionsChange();
                scrollview.scrollTo(0, scrollview._minScrollY);
            } else if (scroll_to >= scrollview._maxScrollY) {
                scrollview._uiDimensionsChange();
                scrollview.scrollTo(0, scrollview._maxScrollY);
            } else {
                scrollview._uiDimensionsChange();
                scrollview.scrollTo(0, scroll_to);
            };

            if (scrollview.scrollbars) {
                scrollview.scrollbars.flash();
            };
        }
        else {
            scrollview._uiDimensionsChange();
            scrollview.scrollTo(0, scroll_end);
        }
    };

    Y.Helper = Helper;

}, '0.1', { requires: ['base-base', 'io-base', 'handlebars'] });