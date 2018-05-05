app.controller("Employees/EmployeeDetailsController", ["$scope", "$http", "$location", "$q", "$route", "$routeParams", "EmployeeService",
    function ($scope, $http, $location, $q, $route, $routeParams, EmployeeService) {

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


        //Add Training Stuff 


        var getAvailableTrainings = function () {
            EmployeeService.getAvailableTrainings($routeParams.id).then(function (results) {
                $scope.programs = results;
            }).catch(function (err) {
                console.log(err);
            });
        }();

        var selectedTrainingsPromises = function (selectedTrainings) {
            selectedTrainings.forEach(function (trainingId) {
                EmployeeService.addEmployeeTraining($routeParams.id, trainingId)
            });
        };

        $scope.addSelectedTrainings = function () {
            var selectedTrainings = getSelectedCheckboxes();
            if (selectedTrainings.length > 0) {
                $scope.$dismiss();
                $q.all(selectedTrainingsPromises(selectedTrainings)).then(function (result) {
                    $route.reload();
                });
            }
        };

        getSelectedCheckboxes = function () {
            var selectedTrainings = [];
            $("input:checkbox[name=training-checkbox]:checked").each(function () {
                selectedTrainings.push(parseInt($(this).val()));
            });
            return selectedTrainings;
        };

        $scope.navigateToEditEmployee = function () {
            $location.path(`/employee-edit/${$routeParams.id}`);
        };
    }
]);