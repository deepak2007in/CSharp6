var myApp = angular.module('myApp', []);
myApp.controller('GreetingController', ['$scope', function ($scope) {
    $scope.greeting = "Hola!";
    $scope.double = function (value) { return value * 2; };
}]);