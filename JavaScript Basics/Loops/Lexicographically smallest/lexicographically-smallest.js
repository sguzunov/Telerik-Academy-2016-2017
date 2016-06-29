(function() {
    'use strict';
    var docMinProperty = '',
        docMaxProperty = '',
        windowMinProperty = '',
        windowMaxProperty = '',
        navigatorMinProperty = '',
        navigatorMaxProperty = '';

    for (let prop in document) {
        if (docMinProperty > prop) {
            docMinProperty = prop;
        }

        if (docMaxProperty < prop) {
            docMaxProperty = prop;
        }
    }

    for (let prop in window) {
        if (windowMinProperty > prop) {
            windowMinProperty = prop;
        }

        if (windowMaxProperty < prop) {
            windowMaxProperty = prop;
        }
    }

    for (let prop in navigator) {
        if (navigatorMinProperty > prop) {
            navigatorMinProperty = prop;
        }

        if (navigatorMaxProperty < prop) {
            navigatorMaxProperty = prop;
        }
    }

    var propertiesDom = document.getElementById('properties');
    propertiesDom.innerHTML += 'document max property: ' + docMaxProperty;
    propertiesDom.innerHTML += 'document min property: ' + docMinProperty;
    propertiesDom.innerHTML += 'window max property: ' + windowMaxProperty;
    propertiesDom.innerHTML += 'window min property: ' + windowMinProperty;
    propertiesDom.innerHTML += 'navigator max property: ' + navigatorMaxProperty;
    propertiesDom.innerHTML += 'navigator min property: ' + navigatorMainProperty;
}());