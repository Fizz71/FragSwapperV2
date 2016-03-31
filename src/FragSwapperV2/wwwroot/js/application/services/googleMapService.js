applicationModule.factory('googleMap', [function () {
    var scopeMarkers = [];
    var scopeMap;
    var infoWindow = new google.maps.InfoWindow();

    var initialize = function (elementID, mapOptions) {
        scopeMap = new google.maps.Map(document.getElementById(elementID), mapOptions);

    }
 
    var pushEventMarkerLogic = function (eventMapItem) {
        // Bounce "Event Day" map items.
        var markerAnimation = (eventMapItem.Status == 'EventDay' ? google.maps.Animation.BOUNCE : google.maps.Animation.DROP);

        // Use custom map images based on the EventStatus Enum's string value.
        var markerImage = '/images/map/' + eventMapItem.Status + '.png'

        // Build the window content for the marker.
        var markerContent = '<div class="infoWindowContent">' + eventMapItem.Name + '</div>'

        // Build the Marker and add it to the map.
        var marker = new google.maps.Marker({
            map: scopeMap,
            position: {lat: eventMapItem.LocationLat, lng: eventMapItem.LocationLng},
            animation: markerAnimation,
            title: eventMapItem.Name,
            icon: markerImage,
            content: markerContent
        });

        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.open(scopeMap, marker);
        });

        scopeMarkers.push(marker);
    };


    var pushEventMarkersLogic = function (eventList, clearMarkers) {
        if (clearMarkers) {
            for (var i = 0; i < scopeMarkers.length; i++) {
                scopeMarkers[i].setMap(null);
            }
            scopeMarkers.length = 0;
        }

        for (var event in eventList.data) {
            pushEventMarkerLogic(eventList.data[event]);
        }
    };

    var openInfoWindowLogic = function (e, selectedMarker) {
        e.preventDefault();
        google.maps.event.trigger(selectedMarker, 'click');
    }

    return {
        map: scopeMap,
        markers: scopeMarkers,
        initializeMap: initialize,
        pushEventMarker: pushEventMarkerLogic,
        pushEventMarkers: pushEventMarkersLogic,
        openInfoWindow: openInfoWindowLogic
    };
}]);
