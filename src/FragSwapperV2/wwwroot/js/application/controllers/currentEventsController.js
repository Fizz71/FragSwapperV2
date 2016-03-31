applicationModule.controller('currentEventsController', function ($scope, $http, googleMap) {

    // Initialize google map for events using our googleMap Service.
    googleMap.initializeMap('map', {
        zoom: 4,
        center: { lat: 40.0000, lng: -98.0000 },
        mapTypeId: google.maps.MapTypeId.TERRAIN
    });
    $scope.map = googleMap.map;
    $scope.markers = googleMap.markers;
    $scope.openInfoWindow = googleMap.openInfoWindow;

    // Asych call to get the current events and create the map markers.
    $scope.eventData = [];
    var promise = $http.get('/api/Events/GetCurrent');
    promise.then(
    function (eventList) {
            googleMap.pushEventMarkers(eventList,false);
    });

});
