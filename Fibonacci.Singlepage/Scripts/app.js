var app = angular.module("fibonacci", []);

app.controller("mainController", function ($scope, $http) {
    $scope.number = "";
    $scope.result = {};
    $scope.calculations = [];
    $scope.numberIsValid = function () {
        return isNaN($scope.number) || $scope.number.length==0;
    }

    $scope.calculate = function () {
        $http.get('Fibonacci/Calculate?number=' + $scope.number).
            success(function (data) {
                $scope.result = data;
                $scope.refreshCalculations();
            }).
            error(function () {
                alert("something went wrong");
            });
    }

    $scope.refreshCalculations = function () {
        $http.get('Fibonacci/GetCalculations').
            success(function (data) {
                $scope.calculations = data;
            }).
            error(function () {
                alert("something went wrong");
            });
    }
    $scope.refreshCalculations();
});