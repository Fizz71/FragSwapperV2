applicationModule.controller('userNotificationsController',
    function ($scope, notificationsService, userNotificationsHub) {
        /*var userCounts = {};
        userCounts["newMessages"] = 1;
        userCounts["newNotification"] = 0;*/

        notificationsService.get().then(function (bmessage) {
            $scope.boomMessage = bmessage;
            $scope.newMessages = 5;
        });

        // Method which receives data.
        userNotificationsHub.client.handleUserNotification = function (bmessage) {
            // Method which handles messages.
            $scope.boomMessage = bmessage;
            $scope.$apply();

        };

        $scope.boom = function () {
            userNotificationsHub.server.handleUserNotification($scope.testValue);
        };

    });