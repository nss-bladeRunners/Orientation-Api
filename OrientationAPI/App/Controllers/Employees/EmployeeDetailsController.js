app.controller("Employees/EmployeeDetailsController", ["$scope", "$http", "$location", "$route", "$routeParams", "EmployeeService",
    function ($scope, $http, $location, $route, $routeParams, EmployeeService) {

        $scope.header = "Employee Details";

        $scope.getEmployeeDetails = function () {
            $http.get(`api/employees/employee-details/${$routeParams.id}`).then(function (result) {
                $scope.employee = result.data;
                console.log($scope.employee);
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
























        //Add Training Stuff 


        var getAvailableTrainings = function () {
            EmployeeService.getAvailableTrainings($routeParams.id).then(function (results) {
                console.log(results);
                $scope.programs = results;
            }).catch(function (err) {
                console.log(err);
            });
        }();

        $scope.addSelectedTrainings = function () {
            var selectedTrainings = getSelectedCheckboxes();
            if (selectedTrainings.length > 0) {
                $scope.$dismiss();
                selectedTrainings.forEach(function (trainingId) {
                    EmployeeService.addEmployeeTraining($routeParams.id, trainingId).then(function (results) {
                        if (results.status = 201) {
                            $route.reload()
                        }                                            
                    }).catch(function (err) {
                        console.log(err);
                    });
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

        

    }
]);