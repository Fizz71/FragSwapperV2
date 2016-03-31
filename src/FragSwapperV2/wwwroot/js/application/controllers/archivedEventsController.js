applicationModule.controller('archivedEventsController', function ($scope, $http, googleMap) {
    // Filter Elements
    $scope.eventName = '';
    $scope.yearList = [];
    for (i = 2004; i <= (new Date).getFullYear() ; i++) {$scope.yearList.push(i.toString());}
    $scope.eventYear = (new Date).getFullYear().toString();

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
    $scope.updateMap = function () {
        var myFilter = {
            EventName: $scope.eventName,
            EventYear: $scope.eventYear
        };

        var promise =
            $http({
                method: 'GET',
                url: '/api/Events/GetArchived',
                params: { filter: angular.toJson(myFilter, false) }
            });

        promise.then(
        function (eventList) {
            googleMap.pushEventMarkers(eventList, true);
        });
    }
    $scope.updateMap();
});
