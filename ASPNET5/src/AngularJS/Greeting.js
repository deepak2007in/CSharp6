var myApp = angular.module('myApp', []);
myApp.controller('SpicyController', ['$scope', function ($scope) {
    $scope.customSpice = "wasabi";
    $scope.spice = "very";
    $scope.spicy = function (spice) {
        $scope.customSpice = spice;
    };
}]);