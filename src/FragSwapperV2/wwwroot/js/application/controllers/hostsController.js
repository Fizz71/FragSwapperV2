applicationModule.controller('hostsController', function ($scope, $http) {
    $scope.wantsPremium = false;

    // Automatically update the Abbreviation based on the Name.
    $scope.updateAbr = function () {
        var matches = $scope.hostName.match(/\b(\w)/g);
        if (matches != null) {
            $scope.hostAbr = matches.join('').toUpperCase();
            $scope.hostShortName = matches.join('').toLowerCase();
        }
        else
        {
            $scope.hostAbr = "";
            $scope.hostShortName = "";
        }
    }


});