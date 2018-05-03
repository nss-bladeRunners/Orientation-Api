app.controller("EmployeeAddController", ["$scope", "$http", "$location", "$routeParams", "EmployeeService",
    function ($scope, $http, $location, $routeParams, EmployeeService) {

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $scope.addNewEmployee = function () {

            $scope.employee.DepartmentId = $scope.department.DepartmentId.DepartmentId;
            EmployeeService.addEmployee($scope.employee).then(function () {
                $scope.navigateToEmployees();
            }).catch(function (err) {
                console.log("Error in EmployeeAddController", err);
            });
        };

        $scope.navigateToEmployees = function () {
            $location.path('/employees');
        };

    }
]);