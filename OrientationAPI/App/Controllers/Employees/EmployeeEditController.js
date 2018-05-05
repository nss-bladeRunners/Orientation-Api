app.controller("EmployeeEditController", ["$scope", "$http", "$location", "$routeParams", "EmployeeService",
    function ($scope, $http, $location, $routeParams, EmployeeService) {

        $scope.header = "Edit Employee";

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $http.get(`api/employees/employee-details/${$routeParams.id}`).then(function (result) {
            $scope.employee = result.data;
            if ($scope.employee.TrainingProgramId > 0) { getEmployeeTraining() };
        }).catch(function (err) {
            console.log(err);
        });

        var getEmployeeTraining = function () {
            $http.get(`/api/employees/employee-details/${$routeParams.id}/training`).then(function (result) {
                $scope.training = result.data;
            }).catch(function (err) {
                console.log(err);
            });
        };

        $scope.saveUpdatedEmployee = function () {
            EmployeeService.updateEmployee($scope.employee).then(function () {
                console.log($scope.employee);
                $location.path(`/employee-details/${$routeParams.id}`);
            }).catch(function (err) {
                console.log("erroe in updateTraining in controller", err);
            });
        };

        $scope.backToEmployees = function () {
            $location.path('/employees');
        };
    }
]);