var app = angular.module("OrientationAPI", ["ngRoute", "angularMoment"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
        })

        .when("/Computers", {
            templateUrl: "/app/partials/Computers.html",
            controller: "ComputerViewCtrl"
        
        .when("/Training",
        {
            templateUrl: "/app/partials/trainingprograms.html",
            controller: "TrainingProgramsController"
        })

        .when("/Computers/Create", {
            templateUrl: "/app/partials/ComputersCreate.html",
            controller: "ComputerViewCtrl"
        })
        .when("/TrainingAdd",
        {
            templateUrl: "/app/partials/TrainingProgramsAdd.html"
        })


        .otherwise('/');
}]);