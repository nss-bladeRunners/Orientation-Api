app.controller("TrainingPrograms/EditController", ["$scope", "$http", "$location", "$routeParams", "TrainingProgramService",
    function ($scope, $http, $location, $routeParams, TrainingProgramService) {

        var updateTraining = function () {
            TrainingProgramService.updateTraining($scope.program).then(function (results) {
                if (results.status === 200) {
                    $location.path(`/Training`);
                }
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err);
            });
        }; 

        var getTrainingById = function () {
            TrainingProgramService.getTrainingById($routeParams.id).then(function (results) {
                results.StartDate = new Date(results.StartDate);
                results.EndDate = new Date(results.EndDate);
                $scope.program = results;
                $scope.programName = angular.copy($scope.program.Name);
                $scope.isFutureTraining();
            }).catch(function (err) {
                console.log("error in updateTraining in controller", err);
            });
        };


        $scope.deleteTraining = function () {
            TrainingProgramService.deleteTraining($routeParams.id).then(function (results) {
                console.log(results);
                $scope.navigateToList();
            }).catch(function (err) {
                console.log("error in deleteTraining in controller", err);
            });
        };


        $scope.navigateToList = function () {
            $location.path(`/Training`);
        };

        $scope.submitUpdatedProgram = function () {
            updateTraining();
        };

        $scope.toggleEditMode = function () {
            $scope.formDisabled = !$scope.formDisabled;
            getTrainingById();
        };

        $scope.isFutureTraining = function () {
            return $scope.program.StartDate > new Date(Date.now()) ? true : false;
        };
    }
]);