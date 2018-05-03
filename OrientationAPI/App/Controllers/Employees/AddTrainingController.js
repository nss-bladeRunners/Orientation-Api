app.controller("Employees/AddTrainingController", ["$scope", "$http", "$location", "$routeParams", "EmployeeService",
    function ($scope, $http, $location, $routeParams, EmployeeService) {

        var getAvailableTrainings = function () {
            EmployeeService.getAvailableTrainings($routeParams.id).then(function (results) {
                console.log(results);
                $scope.programs = results; 
            }).catch(function (err) {
                console.log(err);
            });
        }();

        var addSelectedTrainings = function (employeeId, TrainingIdArray) {

        }
    }
]);