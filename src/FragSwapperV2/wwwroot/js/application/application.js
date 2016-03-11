var applicationModule = angular.module('application', []);

// SignalR's hub object.
var userNotificationsHub = $.connection.userNotificationsHub;

$(function () {
   $.connection.hub.logging = true;
   $.connection.hub.start();
});

angular.module('application').value('userNotificationsHub', userNotificationsHub);
