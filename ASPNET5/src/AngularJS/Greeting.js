var myApp = angular.module('myApp', []);
myApp.controller('SpicyController', ['$scope', function ($scope) {
    $scope.spice = "Very";
    $scope.chiliSpicy = function () {
        $scope.spice = 'Chili';
    };
    $scope.jalapenoSpicy = function () {
        $scope.spice = 'jalapeno';
    }
}]);