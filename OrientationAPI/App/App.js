var app = angular.module("OrientationAPI", ["ngRoute", "angularMoment", "ui.bootstrap"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
        })


        .when("/employees",
        {
            templateUrl: "/app/partials/Employees/Employees.html",
            controller: "EmployeesController"
        })
        .when("/CreateEmployee",
        {
            templateUrl: "/app/partials/Employees/CreateEmployee.html",
            controller: "EmployeeAddController"
        })
        .when("/employee-details/:id",
        {
            templateUrl: "/app/partials/Employees/EmployeeDetails.html",
            controller: "Employees/EmployeeDetailsController"

        })
        .when("/employee-edit/:id",
        {
            templateUrl: "/app/partials/Employees/EditEmployee.html",
            controller: "EmployeeEditController"
        })


        .when("/Training",
        {
            templateUrl: "/app/partials/trainingPrograms/index.html",
            controller: "TrainingPrograms/IndexController"
        })
        .when("/Training/Add",
        {
            templateUrl: "/app/partials/trainingPrograms/add.html"
        })
        .when("/training/:id", {
            templateUrl: "/app/partials/trainingPrograms/edit.html"
        })


        .when("/Departments",
        {
            templateUrl: "/app/partials/Departments/Index.html",
            controller: "DepartmentController"
        })
        .when("/Departments/Add",
        {
            templateUrl: "/app/partials/Departments/Add.html",
            controller: "DepartmentController"
        })
        .when("/Departments/Detail/:departmentId",
        {
            templateUrl: "/app/partials/Departments/Detail.html",
            controller: "DetailController"
        })
        .when("/Departments/Detail/:departmentId/employees",
        {
            templateUrl: "/app/partials/Departments/Detail.html",
            controller: "DetailController"
        })

        
        .when("/Computers", {
            templateUrl: "/app/partials/Computers.html",
            controller: "ComputerViewCtrl"
        })
        .when("/Computers/Create", {
            templateUrl: "/app/partials/ComputersCreate.html",
            controller: "ComputerViewCtrl"
        })
        .when("/Computers/Detail/:computerId", {
            templateUrl: "/app/partials/ComputerDetail.html",
            controller: "ComputerDetailCtrl"
        })

        .otherwise('/');
}]);