var myApp = angular.module('myServiceModule', []);
myApp.controller('MyController', ['$scope', 'notify', function ($scope, notify) {
    $scope.callNotify = function (msg) {
        notify(msg);
    };
}]);
myApp.config(['$provide', function ($provide) {
    $provide.factory('notify', ['$log', function ($log) {
        var msgs = [];
        return function (msg) {
            msgs.push(msg);
            if (msgs.length == 3) {
                $log.log(msgs.join("\n"));
                msgs = [];
            }
        };
    }]);
}]);