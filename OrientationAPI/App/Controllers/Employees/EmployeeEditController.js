app.controller("EmployeeEditController", ["$scope", "$http", "$location", "$routeParams", "EmployeeService",
    function ($scope, $http, $location, $routeParams, EmployeeService) {

        $scope.header = "Edit Employee";

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $http.get("api/computers/unassigned").then(function (result) {
            $scope.computers = result.data;
            console.log($scope.computers);
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

        $scope.deleteComputer = function () {
            EmployeeService.deleteComputer($scope.employee.ComputerId).then(function (results) {
            }).catch(function (err) {
                console.log("error in deleteComputer in controller", err);
            });
        };

        $scope.saveUpdatedEmployee = function () {
            EmployeeService.updateEmployee($scope.employee).then(function () {
                if ($scope.employee.ComputerId > 0) {
                    EmployeeService.deleteComputer($scope.employee.ComputerId).then(function () {
                        EmployeeService.assignComputer($scope.employee.EmployeeId, $scope.computers.ComputerId).then(function () {
                            $location.path(`employee-details/${$scope.employee.EmployeeId}`);
                        });
                    });
                } else {
                    EmployeeService.assignComputer($scope.employee.EmployeeId, $scope.computers.ComputerId).then(function () {
                        $location.path(`employee-details/${$scope.employee.EmployeeId}`);
                    });
                };
            }).catch(function (err) {
                console.log("error in updateEmployee in controller", err);
            });
        };

    
 
        $scope.backToEmployees = function () {
            $location.path('/employees');
        };
    }
]);