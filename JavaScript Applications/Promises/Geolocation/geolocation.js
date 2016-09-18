(function() {
    'use strict';

    function getGeoposition() {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(resolve, reject);
        });
    }

    function getMapSource(position) {
        return new Promise((resolve, reject) => {
            var imgSrc = "http://maps.googleapis.com/maps/api/staticmap?center=" + position.coords.latitude + "," + position.coords.longitude + "&zoom=13&size=500x500&sensor=false";
            resolve(imgSrc);
        });
    }

    function viewMap(mapSrc) {
        let mapImage = document.createElement('img');
        mapImage.setAttribute('src', mapSrc);
        document.getElementById('map-container').appendChild(mapImage);
    }

    getGeoposition()
        .then(getMapSource, (err) => {
            console.log('Error occurred getting current location!');
        })
        .then(viewMap, (err) => {
            console.log('Error occurred loading map image!');
        });
}());