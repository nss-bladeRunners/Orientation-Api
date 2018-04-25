var app = angular.module("OrientationAPI", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
        })

        .when("/Computers", {
            templateUrl: "/app/partials/Computers.html",
            controller: "ComputerViewCtrl"
        })

        .otherwise('/');
}]);