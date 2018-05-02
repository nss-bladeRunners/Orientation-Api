app.controller("EmployeeDetailsController", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.header = "Employee Details";

        $scope.getEmployeeDetails = function () {
            $http.get(`api/employees/employee-details/${$routeParams.id}`).then(function (result) {
                $scope.employee = result.data;
                if ($scope.employee.TrainingProgramId > 0) { getEmployeeTraining() };
            }).catch(function (err) {
                console.log(err);
            });
        };

        var getEmployeeTraining = function () {
            $http.get(`/api/employees/employee-details/${$routeParams.id}/training`).then(function (result) {
                $scope.training = result.data;
            }).catch(function (err) {
                console.log(err);
            });
        };

        $scope.backToEmployees = function () {
            $location.path('/employees');
        }

        $scope.navigateToEditEmployee = function () {
            $location.path(`/employee-edit/${$routeParams.id}`);
        };
    }
]);