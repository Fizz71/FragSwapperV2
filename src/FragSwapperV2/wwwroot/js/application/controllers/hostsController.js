applicationModule.controller('hostsController', function ($scope, $http) {
    $scope.wantsPremium = false;
    $scope.userLocation = { Lat: 40.0000, Lng: -98.0000, RegionID: 0, StateID: 0 }; // Default to the middle of the US.
 
    // Try to get the W3C Geolocation
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            $scope.userLocation = {
                Lat: position.coords.latitude,
                Lng: position.coords.longitude
            };
            var locationPromise = $http({
                method: 'GET',
                url: '/api/Common/GetUserLocationInfo',
                params: { location: angular.toJson($scope.userLocation, false) }
            }).then(function (regionList) {
                $scope.userLocation = regionList.data;
                loadRegions();
            });
        });
    }
    else {
        loadRegions();
    };


    function loadRegions() {
        // Load the Regions.
        var regionPromise = $http({
            method: 'GET',
            url: '/api/Common/GetRegions'
        }).then(function (regionList) {
            $scope.regions = regionList.data;
            $scope.selectedRegion = $.grep($scope.regions, function (e) { return e.ID == $scope.userLocation.RegionID; })[0];
            if ($scope.selectedRegion == null) $scope.selectedRegion = $.grep($scope.regions, function (e) { return e.Name == 'United States'; })[0];
            if ($scope.selectedRegion == null) $scope.selectedRegion = $scope.regions[0];
            $scope.updateStates();
        });
    }

    // Load the States.
    $scope.updateStates = function () {
        var statePromise = $http({
            method: 'GET',
            url: '/api/Common/GetStates',
            params: {
                regionID: $scope.selectedRegion.ID,
               }
        }).then(function (stateList) {
            $scope.states = stateList.data;
            $scope.selectedStates = [$scope.userLocation.StateID]
        });
    }
    
    // Create functionality to automatically update the Abbreviation based on the Name.
    $scope.updateAbr = function () {
        var matches = $scope.hostName.match(/\b(\w)/g);
        if (matches != null) {
            $scope.hostAbr = matches.join('').toUpperCase();
            $scope.hostShortName = matches.join('').toLowerCase();
        }
        else {
            $scope.hostAbr = "";
            $scope.hostShortName = "";
        }
    }

});


