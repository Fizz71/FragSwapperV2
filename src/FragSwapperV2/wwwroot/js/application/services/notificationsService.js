applicationModule.factory('notificationsService', function ($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/api/Notifications').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    };
});