app.controller("TrainingPrograms/IndexController", ["$scope", "$http", "$location", "TrainingProgramService", "ModelTransferService",
    function ($scope, $http, $location, TrainingProgramService, ModelTransferService) {

        var getUpcomingTraining = function () {
            TrainingProgramService.getAllUpcomingPrograms().then(function (results) {
                $scope.programs = results;
            }).catch(function (error) {
                console.log("error in getUpcomingTraining", error);
            });
        }();

        $scope.navigateToAdd = function () {
            var currentLocation = $location.path();
            $location.path(`/Training/Add`);
        }

        $scope.navigateToDetail = function (programId) {
            $location.path(`/training/${programId}`);
        }


    }
]);