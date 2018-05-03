app.controller("EmployeesController", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {
        $scope.header = "Employees";

        $http.get("/api/employees").then(function (result) {
            $scope.employees = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $scope.navigateToCreateEmployee = function () {
            $location.path(`/CreateEmployee`);
        };

        $scope.employeeDetails = function (employeeId) {
            $location.path(`/employee-details/${employeeId}`);
        };

    }
]);